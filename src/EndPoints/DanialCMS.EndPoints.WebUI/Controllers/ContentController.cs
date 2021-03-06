﻿using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.Core.Domain.Contents.Commands;
using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Queries;
using DanialCMS.Core.Domain.FileManagements.Dtos;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Queries;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Queries;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Queries;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.EndPoints.WebUI.Infrastructures;
using DanialCMS.EndPoints.WebUI.Models.Content;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Controllers
{
    [Authorize]
    public class ContentController : BaseController
    {
        private readonly QueryDispatcher _queryDispatcher;
        private readonly CommandDispatcher _commandDispatcher;
        private readonly IAuthorizationService _authorizationService;

        public ContentController(QueryDispatcher queryDispatcher,
            CommandDispatcher commandDispatcher,
            IAuthorizationService authorizationService) : base(queryDispatcher, commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            this._authorizationService = authorizationService;
        }

        public IActionResult Index() => RedirectToAction(nameof(List));

        public IActionResult List(int pageNumber = 1, int pageSize = 10, 
            string orderBy = "date_Desc", List<string> errors = null)
        {
            AddErrosToModelState(errors);
            var allContents = _queryDispatcher.Dispatch<List<DtoListContent>>
                    (new GetContentsQuery());

            allContents = OrderedContents(orderBy, allContents);
            var contents = PaginationContents(ref pageNumber, ref pageSize, allContents);

            if (!contents.Any())
            {
                ModelState.AddModelError("", "مطلبی یافت نشد!");
            }
            return View(contents);
        }


        private List<DtoListContent> OrderedContents(string orderBy, List<DtoListContent> allContents)
        {
            ViewData["PageOrder"] = orderBy;
            if (orderBy == "status_Asc")
            {
                allContents = allContents.OrderBy(c => c.ContentStatus).ToList();
            }
            else if (orderBy == "status_Desc")
            {
                allContents = allContents.OrderByDescending(c => c.ContentStatus).ToList();
            }
            else if (orderBy == "title_Asc")
            {
                allContents = allContents.OrderBy(c => c.Title).ToList();
            }
            else if (orderBy == "title_Desc")
            {
                allContents = allContents.OrderByDescending(c => c.Title).ToList();
            }
            else if (orderBy == "date_Asc")
            {
                allContents = allContents.OrderBy(c => c.PublishDate).ToList();
            }
            else if (orderBy == "date_Desc")
            {
                allContents = allContents.OrderByDescending(c => c.PublishDate).ToList();
            }
            else if (orderBy == "writerName_Asc")
            {
                allContents = allContents.OrderBy(c => c.WriterName).ToList();
            }
            else if (orderBy == "writerName_Desc")
            {
                allContents = allContents.OrderByDescending(c => c.WriterName).ToList();
            }

            return allContents;
        }

        private List<DtoListContent> PaginationContents(ref int pageNumber, ref int pageSize, List<DtoListContent> allContents)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }
            int numberOfPages = Convert.ToInt32(Math.Ceiling((decimal)allContents.Count() / pageSize));
            if (pageNumber > numberOfPages)
            {
                pageNumber = numberOfPages;
            }

            ViewData["NumberOfPages"] = numberOfPages;
            ViewData["PageNumber"] = pageNumber;
            ViewData["PageSize"] = pageSize;
            var contents = allContents.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return contents;
        }

 

        public IActionResult Add()
        {
            var model = new AddContentViewModel();

            model.AllCategories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery());
            model.AllKeywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());
            model.AllPublishPlaces = _queryDispatcher.Dispatch<List<PublishPlace>>(new GetPlacesQuery());
            model.AllPhotos = _queryDispatcher.Dispatch<List<DtoPhotoList>>(new GetPhotosQuery());

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new AddContentCommand()
                {
                    Description = model.Description,
                    Title = model.Title,
                    Body = model.Body,
                    CategoryId = model.CategoryId,
                    PublishDate = model.PublishDate,
                    WriterId = _queryDispatcher.Dispatch<long>(new GetWriterIdQuery()
                         { WriterName = User.Identity.Name }),
                    Rate = model.Rate,
                    PublishPlacesId = model.PublishPlacesId,
                    KeywordsId = model.KeywordsId,
                    PhotoId = model.ContentPhotoId,
                });

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(List));
                }
                AddCommadErrorsToModelState(result);
            }
            model.AllCategories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery());
            model.AllKeywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());
            model.AllPublishPlaces = _queryDispatcher.Dispatch<List<PublishPlace>>(new GetPlacesQuery());

            return View(model);
        }


        public async Task<IActionResult> Update(long id)
        {
            var viewModel = new UpdateContentViewModel();
            var model = _queryDispatcher.Dispatch<DtoUpdateContent>(new GetContentQuery() { ContentId = id });
            if (model == null)
            {
                return View(model);
            }

            var authResult = await _authorizationService.AuthorizeAsync(User, model
                , "WriterAndEditors");
            if (authResult.Succeeded)
            {
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
                viewModel.AllPhotos = _queryDispatcher.Dispatch<List<DtoPhotoList>>(new GetPhotosQuery());

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("AccessDenied", "Account");
            }

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbModel = _queryDispatcher.Dispatch<DtoUpdateContent>(new GetContentQuery() { ContentId = model.Id });

                var authResult = await _authorizationService.AuthorizeAsync(User, dbModel
                , "WriterAndEditors");

                if (authResult.Succeeded)
                {
                    var result = _commandDispatcher.Dispatch(new EditContentCommand()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Body = model.Body,
                        Rate = model.Rate,
                        PublishDate = model.PublishDate,
                        Id = model.Id,
                        PhotoId = model.PhotoId,

                        CategoryId = model.CategoryId,
                        KeywordsId = model.KeywordsId,
                        publishPlacesId = model.PublishPlacesId,
                    });
                    if (result.IsSuccess)
                    {
                        return RedirectToAction(nameof(List));
                    }
                    AddCommadErrorsToModelState(result);
                }
                else
                {
                    return RedirectToAction("AccessDenied", "Account");
                }
            }
            model.AllCategories = _queryDispatcher.Dispatch<List<Category>>(new GetCategoriesQuery());
            model.AllKeywords = _queryDispatcher.Dispatch<List<Keyword>>(new GetKeywordsQuery());
            model.AllPublishPlaces = _queryDispatcher.Dispatch<List<PublishPlace>>(new GetPlacesQuery());
            model.PublishPlacesId = new List<long>();
            model.KeywordsId = new List<long>();
            return View(model);
        }

        public async Task<IActionResult> Show(long id)
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
            viewModel.Comments = model.Comments;
            viewModel.CategoryName = model.Category.Name;
            viewModel.KeywordsName = model.Keywords.Select(c => c.Name).ToList();
            viewModel.publishPlacesName = model.PublishPlaces.Select(c => c.Name).ToList();
            viewModel.WriterName = model.Writer.Name;
            viewModel.PhotoUrl = _queryDispatcher.Dispatch<FileManagement>(new GetFileQuery { Id = model.PhotoId })?.Url;

            return View(viewModel);
            
        }


        [HttpPost]
        public IActionResult ChangeToDelete(long id, string returnUrl = "List")
        {
            var result = _commandDispatcher.Dispatch(new EditStatusContentCommand() { Id = id, ContentStatus = ContentStatus.Deleted });
            if (!result.IsSuccess)
            {
                AddCommadErrorsToModelState(result);
            }

            var path = returnUrl.Trim('/').Split("/").ToList();
            if (path.Count == 1)
            {
                return RedirectToAction(path[0], new { errors = GetErrosFromModelState() });
            }
            else
            {
                return RedirectToAction(path[1], path[0], new { errors = GetErrosFromModelState() });
            }
        }
        [HttpPost]
        public IActionResult ChangeToWait(long id, string returnUrl = "List")
        {
            var result = _commandDispatcher.Dispatch(new EditStatusContentCommand() { Id = id, ContentStatus = ContentStatus.Waiting });
            if (!result.IsSuccess)
            {
                AddCommadErrorsToModelState(result);
            }

            var path = returnUrl.Trim('/').Split("/").ToList();
            if (path.Count == 1)
            {
                return RedirectToAction(path[0], new { errors = GetErrosFromModelState() });
            }
            else
            {
                return RedirectToAction(path[1], path[0], new { errors = GetErrosFromModelState() });
            }
        }
        [HttpPost]
        public IActionResult ChangeToPublish(long id, string returnUrl = "List")
        {
            var result = _commandDispatcher.Dispatch(new EditStatusContentCommand() { Id = id, ContentStatus = ContentStatus.Published });
            if (!result.IsSuccess)
            {
                AddCommadErrorsToModelState(result);
            }

            var path = returnUrl.Trim('/').Split("/").ToList();
            if (path.Count == 1)
            {
                return RedirectToAction(path[0], new { errors = GetErrosFromModelState() });
            }
            else
            {
                return RedirectToAction(path[1], path[0], new { errors = GetErrosFromModelState() });
            }
        }








    }
}

