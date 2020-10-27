using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.Comments.Commands;
using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Comments.Queries;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Web;
using Microsoft.AspNetCore.Mvc;



namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class CommentController : BaseController
    {
        private readonly QueryDispatcher _queryDispatcher;
        private readonly CommandDispatcher _commandDispatcher;

        public CommentController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        //view mikhad
        public IActionResult List()
        {
            var comments = _queryDispatcher.Dispatch<List<Comment>>(new GetCommentsQuery());
            return View(comments);
        }

        public IActionResult ChangeStatus(long id, bool status, string returnUrl = "Comment/List")
        {
            var result = _commandDispatcher.Dispatch(new ChangeStatusCommentCommand() { CommentId = id, CommentStatus = status });
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
