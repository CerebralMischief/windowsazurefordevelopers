using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkTrunk.Controllers;

namespace JunkTrunk.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            var viewData = result.ViewData;
            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }

        [TestMethod]
        public void About()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Upload()
        {
            var controller = new HomeController();
            var result = controller.Upload();
            Assert.IsNotNull(result);
        }
    }
}