using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.EndPoints.WebUI.Infrastructures;
using DanialCMS.EndPoints.WebUI.Models.Writer;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DanialCMS.EndPoints.WebUI.Controllers
{
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
            var writer = _queryDispatcher.Dispatch<DtoWriterDetail>(new WriterDetailQuery() { Id = id });
            return View(writer);
        }

        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddWriterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dtoPhoto = new FileSaver().Save(model.file);
                
                var result = _commandDispatcher.Dispatch(new AddWriterCommand()
                {
                    Name = model.Name,
                    Photo = dtoPhoto
                });
                if (result.IsSuccess)
                {
                    return List();
                }
                ModelState.AddModelError("", result.Message);
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View();
        }


        public IActionResult Update(long id)
        {
            var writer = _queryDispatcher.Dispatch<DtoUpdateWriter>(new WriterUpdateQuery() { Id = id });
            if (writer == null)
            {
                ModelState.AddModelError("", "نویسنده یافت نشد"); /* momkene ziadi bashe! */
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
        public IActionResult Update(EditWriterNameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _commandDispatcher.Dispatch(new EditWriterNameCommand()
                {
                    Id = model.Id,
                    Name = model.Name
                });
                if (result.IsSuccess)
                {
                    return List();
                }
                ModelState.AddModelError("", result.Message);
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Update(EditWriterPhotoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dtoPhoto = new FileSaver().Save(model.File);

                var result = _commandDispatcher.Dispatch(new ChangeWriterPhotoCommand()
                {
                    WriterId = model.WriterId,
                    Photo = dtoPhoto
                });
                if (result.IsSuccess)
                {
                    return List();
                }
                ModelState.AddModelError("", result.Message);
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View();
        }
    }
}
