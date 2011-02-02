using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using JunkTrunk.Models;
using JunkTrunk.Storage;

namespace JunkTrunk.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Table.ClearAllData();
            ViewData["Message"] = "Welcome to the Windows Azure Blob Storing ASP.NET MVC Web Application!";
            var repository = new FileBlobRepository();
            var fileItemModels = repository.GetBlobFileList();
            return View(fileItemModels);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var repository = new FileBlobRepository();
            ViewData["Blobs"] = repository.GetBlobFileList();
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
                        new BlobModel
                            {
                                BlobFile = file.InputStream,
                                UploadedOn = DateTime.Now,
                                ResourceLocation = Path.GetFileName(file.FileName)
                            };

                    var repository = new FileBlobRepository();
                    repository.PutFile(blobFileModel);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(string identifier)
        {
            var key = Guid.Parse(identifier);
            var fileBlobRepository = new FileBlobRepository();
            var blobFile = fileBlobRepository.GetFile(key);
            return View(blobFile);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(FileItemModel fileItemModel)
        {

        }
    }
}