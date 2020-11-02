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


        public IActionResult Index() => RedirectToAction(nameof(List));


        public IActionResult List(int pageNumber = 1, int pageSize = 10, string orderBy = "show_Desc")
        {
            var allComments = _queryDispatcher.Dispatch<List<Comment>>(new GetCommentsQuery());

            allComments = orderedComments(orderBy, allComments);
            var comments = PaginationComments(ref pageNumber, ref pageSize, allComments);

            return View(comments);
        }

        private List<Comment> orderedComments(string orderBy, List<Comment> allComments)
        {
            ViewData["PageOrder"] = orderBy;
            if (orderBy == "show_Asc")
            {
                allComments = allComments.OrderBy(c => c.CanShow).ToList();
            }
            else if (orderBy == "show_Desc")
            {
                allComments = allComments.OrderByDescending(c => c.CanShow).ToList();
            }
            else if (orderBy == "userName_Asc")
            {
                allComments = allComments.OrderBy(c => c.Name).ToList();
            }
            else if (orderBy == "userName_Desc")
            {
                allComments = allComments.OrderByDescending(c => c.Name).ToList();
            }
            else if (orderBy == "date_Asc")
            {
                allComments = allComments.OrderBy(c => c.PublishDate).ToList();
            }
            else if (orderBy == "date_Desc")
            {
                allComments = allComments.OrderByDescending(c => c.PublishDate).ToList();
            }
            else if (orderBy == "Email_Asc")
            {
                allComments = allComments.OrderBy(c => c.Email).ToList();
            }
            else if (orderBy == "Email_Desc")
            {
                allComments = allComments.OrderByDescending(c => c.Email).ToList();
            }

            return allComments;
        }

        private List<Comment> PaginationComments(ref int pageNumber, ref int pageSize, List<Comment> allComments)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }
            int numberOfPages = Convert.ToInt32(Math.Ceiling((decimal)allComments.Count() / pageSize));
            if (pageNumber > numberOfPages)
            {
                pageNumber = numberOfPages;
            }

            ViewData["NumberOfPages"] = numberOfPages;
            ViewData["PageNumber"] = pageNumber;
            ViewData["PageSize"] = pageSize;

            var comments = allComments.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return comments;
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
