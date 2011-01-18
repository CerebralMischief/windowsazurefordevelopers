using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Athenaeum.WebRole.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Athenaeum.WebRole.Tests.Controllers
{
    [TestClass]
    public class BlobControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller =new BlobController();
            Assert.IsNotNull(controller);
        }
    }

 
}
