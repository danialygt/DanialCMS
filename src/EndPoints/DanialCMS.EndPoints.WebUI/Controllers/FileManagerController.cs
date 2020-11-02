using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Queries;
using DanialCMS.EndPoints.WebUI.Infrastructures;
using DanialCMS.EndPoints.WebUI.Models.FileManager;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Mvc;



namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class FileManagerController : BaseController
    {
        private readonly QueryDispatcher _queryDispatcher;
        private readonly CommandDispatcher _commandDispatcher;

        public FileManagerController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public IActionResult Index() => RedirectToAction(nameof(List));

        public IActionResult List(int pageNumber = 1, int pageSize = 10, 
            string orderBy = "name_Asc", List<string> errors = null)
        {
            AddErrosToModelState(errors);
            var allFiles = _queryDispatcher.Dispatch<List<FileManagement>>(new GetFilesQuery());

            allFiles = OrderedFiles(orderBy, allFiles);


            var files = PaginationFiles(ref pageNumber, ref pageSize, allFiles);

            if (!files.Any())
            {
                ModelState.AddModelError("", "فایلی یافت نشد!");
            }
            return View(files);
        }

        private List<FileManagement> OrderedFiles(string orderBy, List<FileManagement> allFiles)
        {
            ViewData["PageOrder"] = orderBy;
            if (orderBy == "name_Asc")
            {
                allFiles = allFiles.OrderBy(c => c.Name).ToList();
            }
            else if (orderBy == "name_Desc")
            {
                allFiles = allFiles.OrderByDescending(c => c.Name).ToList();
            }
            else if (orderBy == "size_Asc")
            {
                allFiles = allFiles.OrderBy(c => c.Size).ToList();
            }
            else if (orderBy == "size_Desc")
            {
                allFiles = allFiles.OrderByDescending(c => c.Size).ToList();
            }
            else if (orderBy == "date_Asc")
            {
                allFiles = allFiles.OrderBy(c => c.Date).ToList();
            }
            else if (orderBy == "date_Desc")
            {
                allFiles = allFiles.OrderByDescending(c => c.Date).ToList();
            }
            else if (orderBy == "type_Asc")
            {
                allFiles = allFiles.OrderBy(c => c.Type).ToList();
            }
            else if (orderBy == "type_Desc")
            {
                allFiles = allFiles.OrderByDescending(c => c.Type).ToList();
            }

            return allFiles;
        }

        private List<FileManagement> PaginationFiles(ref int pageNumber, ref int pageSize, List<FileManagement> allFiles)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }
            int numberOfPages = Convert.ToInt32(Math.Ceiling((decimal)allFiles.Count() / pageSize));
            if (pageNumber > numberOfPages)
            {
                pageNumber = numberOfPages;
            }

            ViewData["NumberOfPages"] = numberOfPages;
            ViewData["PageNumber"] = pageNumber;
            ViewData["PageSize"] = pageSize;

            var files = allFiles.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return files;
        }

        public IActionResult Add()
        {
            return View(new AddFileViewModel());
        }
        [HttpPost]
        public IActionResult Add(AddFileViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSucced = true;
                    foreach (var item in model.Files)
                    {
                        var dtoPhoto = new FileManager().Save(item);

                        var result = _commandDispatcher.Dispatch(new AddFileCommand()
                        {
                            FileName = dtoPhoto.FileName,
                            FileSize = dtoPhoto.FileSize,
                            FileType = dtoPhoto.FileType,
                            FileUrl = dtoPhoto.FileUrl,
                        });

                        if (!string.IsNullOrEmpty(result.Message))
                        {
                            ModelState.AddModelError("", result.Message);
                        }
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError("", err);
                        }

                        isSucced = isSucced && result.IsSuccess;
                    }

                    if (isSucced)
                    {
                        return RedirectToAction(nameof(List));
                    }
                }
                catch (TypeAccessException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Remove(RemoveViewModel model)
        {
            var result = _commandDispatcher.Dispatch(new RemoveFileCommand() { Id = model.Id });
            if (result.IsSuccess)
            {
                new FileManager().Delete(model.Url);
            }
            else
            {
                AddCommadErrorsToModelState(result);
            }
            return RedirectToAction(nameof(List), new
                { errors = GetErrosFromModelState() });
        }

        public IActionResult Update(long id)
        { 
            var file = _queryDispatcher.Dispatch<FileManagement>(new GetFileQuery() { Id = id });
            if (file != null)
            {
                return View(new RenameFileViewModel() { Name = file.Name, Id = id });
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(RenameFileViewModel model)
        {
            var result = _commandDispatcher.Dispatch(new RenameFileCommand() 
            { 
                Id = model.Id, 
                Name = model.Name
            });
            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(List));
            }
            if (!string.IsNullOrEmpty(result.Message))
            {
                ModelState.AddModelError("", result.Message);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return View(model);    
        }







    }
}
