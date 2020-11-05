using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace DanialCMS.EndPoints.WebUI.Controllers
{
    public class ClaimsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View(User?.Claims);
        }

       
    }
}
