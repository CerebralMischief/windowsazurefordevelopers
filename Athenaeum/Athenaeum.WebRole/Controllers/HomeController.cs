using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Athenaeum.WebRole.Models;
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

        public ActionResult Upload()
        {
            foreach (string inputTagName in Request.Files)
            {
                var file = Request.Files[inputTagName];
                if (file.ContentLength > 0)
                {
                    var blobFileModel =
                        new BlobFileModel
                            {
                                BlobFile = file.InputStream,
                                Description = "I'll add a field for this.",
                                DownloadedOn = DateTime.Now,
                                FileName = Path.GetFileName(file.FileName)
                            };

                    var repository = new FileBlobRepository();
                    repository.PutFile(blobFileModel);
                }
            }

            return RedirectToAction("Index", "Home");
        }



    }
}
