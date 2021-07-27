using NUnit.Framework;

namespace M11_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    public class TestLogin : BaseTest
    {
        [Test]
        public void Login()
        {
            Assert.IsTrue(_homePage.FindAccountIconByAccountName(),
               "The login is not successful. Account Name has not been found!");
        }
    }
}