using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.EndPoints.WebUI.Infrastructures;
using DanialCMS.EndPoints.WebUI.Models.Writer;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DanialCMS.EndPoints.WebUI.Controllers
{
    [Authorize(Roles ="نویسنده")]
    public class WriterController : BaseController
    {
        public WriterController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
        }

        public IActionResult List()
        {
            var allWriter = _queryDispatcher.Dispatch<List<DtoWriter>>(new AllWriterQuery());
            return View(allWriter);
        }

       
        public IActionResult Detail(long id)
        {
            if(id == 0)
            {
                return RedirectToAction(nameof(List));
            }
            var writer = _queryDispatcher.Dispatch<DtoWriterDetail>(new WriterDetailQuery() { Id = id });
            return View(writer);
        }

        
        public IActionResult Add()
        {
            return View(new AddWriterViewModel());
        }

        [HttpPost]
        public IActionResult Add(AddWriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    var dtoPhoto = new FileManager().Save(model.file, shouldImage:true);

                    var result = _commandDispatcher.Dispatch(new AddWriterCommand()
                    {
                        Name = model.Name,
                        Photo = dtoPhoto
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
                }
                catch (TypeAccessException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }


        public IActionResult Update(long id)
        {
            var writer = _queryDispatcher.Dispatch<DtoUpdateWriter>(new WriterUpdateQuery() { Id = id });
            if (writer == null)
            {
                ModelState.AddModelError("", "نویسنده یافت نشد");
                return View();
            }
            var editWriterNameViewModel = new EditWriterViewModel()
            {
                Id = id,
                Name = writer.Name,
                PhotoUrl = writer.PhotoUrl,
                PhotoId = writer.PhotoId
            }; 
            return View(editWriterNameViewModel);
        }


        [HttpPost]
        public IActionResult Update(EditWriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dtoPhoto = new FileManager().Save(model.File, shouldImage: true);

                var result = _commandDispatcher.Dispatch(new UpdateWriterCommand()
                {
                    WriterId = model.Id,
                    Photo = dtoPhoto,
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
            }
            return RedirectToAction(nameof(Update), model.Id);
        }
    }
}
