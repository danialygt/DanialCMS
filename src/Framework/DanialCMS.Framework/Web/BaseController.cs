using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace DanialCMS.Framework.Web
{
    public class BaseController : Controller
    {

        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly CommandDispatcher _commandDispatcher;



        public BaseController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;

        }



        protected void AddCommadErrorsToModelState(CommandResult result)
        {
            if (result.Message != null)
            {
                ModelState.AddModelError("", result.Message);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
        }
        protected List<string> GetErrosFromModelState()
        {
            var modelErrors = new List<string>();
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
            }
            return modelErrors;
        }

        protected void AddErrosToModelState(List<string> errors)
        {
            if (errors != null)
            {
                foreach (var err in errors)
                {
                    ModelState.AddModelError("", err);
                }
            }
        }
    }
}
