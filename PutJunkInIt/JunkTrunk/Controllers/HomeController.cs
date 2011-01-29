using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using JunkTrunk.Models;

namespace JunkTrunk.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult UploadFile()
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
                                Description = "We can add a description of some sort here.",
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