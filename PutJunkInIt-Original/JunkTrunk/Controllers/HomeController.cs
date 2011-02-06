using System;
using System.IO;
using System.Web.Mvc;
using JunkTrunk.Models;

namespace JunkTrunk.Controllers
{
[HandleError]
public class HomeController : Controller
{
    public ActionResult Index()
    {
        ViewData["Message"] = "Welcome to the Windows Azure Blob Storing ASP.NET MVC Web Application!";
        var fileBlobManager = new FileBlobManager();
        var fileItemModels = fileBlobManager.GetBlobFileList();
        return View(fileItemModels);
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
                    new BlobModel
                        {
                            BlobFile = file.InputStream,
                            UploadedOn = DateTime.Now,
                            ResourceLocation = Path.GetFileName(file.FileName)
                        };

                var fileBlobManager = new FileBlobManager();
                fileBlobManager.PutFile(blobFileModel);
            }
        }

        return RedirectToAction("Index", "Home");
    }

    public ActionResult Delete(string identifier)
    {
        var fileBlobManager = new FileBlobManager();
        fileBlobManager.Delete(identifier);
        return RedirectToAction("Index", "Home");
    }
}
}