using System;
using System.Collections.Generic;
using System.IO;
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

        public void Upload()
        {
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (file.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads")
                    , Path.GetFileName(file.FileName));
                    
                    //TODO: Save it to the blob here (where's my class?)
                }
            }

            RedirectToAction("Index", "Home");
        }



    }
}
