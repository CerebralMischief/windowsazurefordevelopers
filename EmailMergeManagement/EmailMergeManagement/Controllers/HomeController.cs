using System.Web.Mvc;

namespace EmailMergeManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Windows Azure Storage Samples";
            return View();
        }
    }
}