using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.Keywords.Commands;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Queries;
using DanialCMS.EndPoints.WebUI.Models.Keyword;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Mvc;


namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class KeywordController : BaseController
    {
        public KeywordController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        public IActionResult List()
        {
            var keywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());

            return View(keywords);
        }

        public IActionResult Add()
        {
            return View(new AddKeywordViewModel());
        }
        [HttpPost]
        public IActionResult Add(AddKeywordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new AddKeywordCommand() { Name = model.Name });
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
        public IActionResult Delete(long id)
        {
            _commandDispatcher.Dispatch(new RemoveKeywordCommand { Id = id });
            return RedirectToAction(nameof(List));
        }
        public IActionResult Update(long id)
        {
            var category = _queryDispatcher.Dispatch<Keyword>(new GetKeywordQuery() { Id = id });
            if (category != null)
            {
                return View(new UpdateKeywordViewModel() { Name = category.Name, KeywordId = id });
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateKeywordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new UpdateKeywordCommand() { Name = model.Name, KeywordId = model.KeywordId });
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
