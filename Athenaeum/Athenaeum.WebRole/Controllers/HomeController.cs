using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Athenaeum.WebRole.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            ViewData["RoleInformation"] = RoleEnvironment.CurrentRoleInstance;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
