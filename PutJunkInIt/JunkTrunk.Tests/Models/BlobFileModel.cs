using JunkTrunk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JunkTrunk.Tests.Models
{
    [TestClass]
    public class BlobFileModelTests
    {
        [TestMethod]
        public void InstantiateBlobFileModel()
        {
            var blobFileModel = new BlobModel();
            Assert.IsNotNull(blobFileModel);
        }
    }
}
