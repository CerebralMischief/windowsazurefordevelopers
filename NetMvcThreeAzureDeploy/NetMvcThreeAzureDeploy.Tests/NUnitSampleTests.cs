using NUnit.Framework;

namespace NetMvcThreeAzureDeploy.Tests {
    [TestFixture]
    public class NUnitSampleTests {
        [Test]
        public void SomePassingTest() {
            Assert.AreEqual(5, 5);
        }

        [Test]
        public void SomeFailingTest() {
            Assert.Greater(8, 7);
        }
    }
}
