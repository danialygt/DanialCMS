using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

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
    }
}
