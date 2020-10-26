using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.Core.Domain.Contents.Commands;
using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Queries;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Queries;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Queries;
using DanialCMS.EndPoints.WebUI.Models.Content;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class ContentController : BaseController
    {
        private readonly QueryDispatcher _queryDispatcher;
        private readonly CommandDispatcher _commandDispatcher;

        public ContentController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public IActionResult List()
        {
            var Contents = _queryDispatcher.Dispatch<List<DtoListContent>>(new GetContentsQuery());
            return View(Contents);
        }

        public IActionResult Add()
        {
            var model = new AddContentViewModel();

            model.AllCategories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery());
            model.AllKeywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());
            model.AllPublishPlaces = _queryDispatcher.Dispatch<List<PublishPlace>>(new GetPlacesQuery());

            return View(model);
        }
        // tasvire file bayad neshon dade beshe to view add!

        [HttpPost]
        public IActionResult Add(AddContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // inja bayad photo az user gerefte beshe

                // writer id inja bayad por beshe! 
                model.WriterId = 2;
                var result = _commandDispatcher.Dispatch(new AddContentCommand()
                {
                    Description = model.Description,
                    Title = model.Title,
                    Body = model.Body,
                    CategoryId = model.CategoryId,
                    PublishDate = model.PublishDate,
                    WriterId = model.WriterId,
                    Rate = model.Rate,
                    PublishPlacesId = model.PublishPlacesId,
                    KeywordsId = model.KeywordsId,
                    dtoPhoto = new Core.Domain.FileManagements.Dtos.DtoFile() // inja bayad avaz beshe
                });

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
            model.AllCategories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery());
            model.AllKeywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());
            model.AllPublishPlaces = _queryDispatcher.Dispatch<List<PublishPlace>>(new GetPlacesQuery());

            return View(model);
        }

        public IActionResult Update(long id)
        {
            var viewModel = new UpdateContentViewModel();
            var model = _queryDispatcher.Dispatch<DtoUpdateContent>(new GetContentQuery() { ContentId = id });
            if(model == null)
            {
                return View(model);
            }
            viewModel.Title = model.Title;
            viewModel.Description = model.Description;
            viewModel.Body = model.Body;
            viewModel.Rate = model.Rate;
            viewModel.PublishDate = model.PublishDate;
            viewModel.WriterName = model.WriterName;
            viewModel.Id = model.Id;

            viewModel.CategoryId = model.CategoryId;
            viewModel.KeywordsId = model.KeywordsId;
            viewModel.PublishPlacesId = model.PublishPlacesId;
            
            viewModel.PhotoUrl = model.PhotoUrl;
            viewModel.PhotoId = model.PhotoId;


            viewModel.AllCategories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery());
            viewModel.AllKeywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());
            viewModel.AllPublishPlaces = _queryDispatcher.Dispatch<List<PublishPlace>>(new GetPlacesQuery());


            return View(viewModel);
        }

        // tasvire file bayad neshon dade beshe to view update!
     
        [HttpPost]
        public IActionResult Update(UpdateContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new EditContentCommand() 
                {
                    Title = model.Title,
                    Description = model.Description,
                    Body = model.Body,
                    Rate = model.Rate,
                    PublishDate = model.PublishDate,
                    Id = model.Id,

                    CategoryId = model.CategoryId,
                    KeywordsId = model.KeywordsId,
                    publishPlacesId = model.PublishPlacesId,                    
                });
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
            return View(model);
        }

        public IActionResult Show(long id)
        {
            var viewModel = new ShowContentViewModel();
            var model = _queryDispatcher.Dispatch<DtoContent>(new GetContentQuery() { ContentId = id });
            if (model == null)
            {
                return View(model);
            }
            viewModel.Title = model.Title;
            viewModel.Description = model.Description;
            viewModel.Body = model.Body;
            viewModel.Rate = model.Rate;
            viewModel.PublishDate = model.PublishDate;

            viewModel.CategoryName = model.Category.Name;
            viewModel.KeywordsName = model.Keywords.Select(c => c.Name).ToList();
            viewModel.publishPlacesName = model.PublishPlaces.Select(c=>c.Name).ToList();
            viewModel.WriterName = model.Writer.Name;

            return View(viewModel);
        }

        public IActionResult ChangeToDelete(long id, string returnUrl = "List")
        {
            var result = _commandDispatcher.Dispatch(new EditStatusContentCommand() { Id = id, ContentStatus = ContentStatus.Deleted});
            if (result.IsSuccess)
            {
                return Redirect(returnUrl);
            }
            if (result.Message != null)
            {
                ModelState.AddModelError("", result.Message);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return Redirect(returnUrl); // inja bayad bere be eeror
        }
        public IActionResult ChangeToWait(long id, string returnUrl = "List")
        {
            var result = _commandDispatcher.Dispatch(new EditStatusContentCommand() { Id = id, ContentStatus = ContentStatus.Waiting });
            if (result.IsSuccess)
            {
                return Redirect(returnUrl);
            }
            if (result.Message != null)
            {
                ModelState.AddModelError("", result.Message);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return Redirect(returnUrl); // inja bayad bere be eeror
        }
        public IActionResult ChangeToPublish(long id, string returnUrl = "List")
        {
            var result = _commandDispatcher.Dispatch(new EditStatusContentCommand() { Id = id, ContentStatus = ContentStatus.Published });
            if (result.IsSuccess)
            {
                return Redirect(returnUrl);
            }
            if (result.Message != null)
            {
                ModelState.AddModelError("", result.Message);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return Redirect(returnUrl);
        }


    }
}

