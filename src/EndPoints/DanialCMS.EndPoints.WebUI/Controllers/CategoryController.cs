using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.Categories.Commands;
using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.EndPoints.WebUI.Models.Category;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DanialCMS.EndPoints.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : BaseController
    {
        private readonly QueryDispatcher _queryDispatcher;
        private readonly CommandDispatcher _commandDispatcher;

        public CategoryController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public IActionResult Index() => RedirectToAction(nameof(List));


        public IActionResult List()
        {
            var categories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery()); 

            return View(categories);
        }

        public IActionResult Add()
        {
            return View(new AddCategoryViewModel());
        }
        [HttpPost]
        public IActionResult Add(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new AddCategoryCommand() { Name = model.Name });
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(List));
                }
                if(result.Message != null)
                {
                    ModelState.AddModelError("", result.Message);
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View();
        }
        public IActionResult Delete(long id)
        {
            _commandDispatcher.Dispatch(new RemoveCategoryCommand { Id = id });
            return RedirectToAction(nameof(List));
        }
        public IActionResult Update(long id)
        {
            var category = _queryDispatcher.Dispatch<Category>(new GetcategoryQuery() { Id = id });
            if (category != null)
            {
                return View(new UpdateCategoryViewModel() {Name = category.Name, CategoryId = id });
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new UpdateCategoryCommand() { Name = model.Name, CategoryId = model.CategoryId });
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(List));
                }
                if (result.Message != null)
                {
                    ModelState.AddModelError("", result.Message);
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View();
        }
   
    }
}
