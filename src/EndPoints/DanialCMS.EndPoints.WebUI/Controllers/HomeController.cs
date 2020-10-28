using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DanialCMS.EndPoints.WebUI.Models;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.EndPoints.WebUI.Infrastructures.Middlewares;
using DanialCMS.EndPoints.WebUI.Infrastructures;
using DanialCMS.Framework.Web;
using DanialCMS.Framework.Queries;
using DanialCMS.Framework.Commands;
using DanialCMS.Core.Domain.Analysis.Queries;
using DanialCMS.EndPoints.WebUI.Models.Home;

namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QueryDispatcher _queryDispatcher;
        private readonly CommandDispatcher _commandDispatcher;

        public HomeController(ILogger<HomeController> logger, QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher) : base(queryDispatcher, commandDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public IActionResult Index()
        {
            var model = new ViewersStatisticsViewModel();

            var date = DateTime.Now.Date;
            model.TodayViews = _queryDispatcher.Dispatch<int>(new GetViewsOnDateQuery() 
            { Date = date });

            model.MonthViews = _queryDispatcher.Dispatch<int>(new GetViewsOnDateQuery()
            { Date = date.AddMonths(-1) });

            model.AllViews = _queryDispatcher.Dispatch<int>(new GetViewsOnDateQuery() 
            { Date = DateTime.MinValue.Date });
            
            
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
