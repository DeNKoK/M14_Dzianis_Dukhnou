using NUnit.Framework;
using M11_Dzianis_Dukhnou.WebObjects;
using M11_Dzianis_Dukhnou.WebDriver;
using M11_Dzianis_Dukhnou.Utilities;
using M11_Dzianis_Dukhnou.Entities;
using System.Diagnostics;
using log4net.Config;
using log4net;
using System.IO;
using System;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace M11_Dzianis_Dukhnou
{
    public abstract class BaseTest
    {
        #region Variables

        protected Computer Computer;
        protected Browser Browser;
        protected StringRandomHelper randomString;
        protected static ILog Log;
        protected User user;
        protected Letter letter;

        protected StartPage _startPage;
        protected LoginPage _loginPage;
        protected HomePage _homePage;
        protected LetterPage _letterPage;
        protected DraftPage _draftPage;
        protected SentPage _sentPage;
        protected InboxPage _inboxPage;
        protected UserMenuPage _userMenuPage;
        protected RightClickMenuPage _rightClickMenuPage;

        #endregion

        [OneTimeSetUp]
        public void ConfigureLog()
        {
            Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        [SetUp]
        public void SetUp()
        {
            Computer = new Computer();
            Computer.Launch("windows");
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo();
            user = new User(
                Configuration.UserID,
                Configuration.Password
                );
            randomString = new StringRandomHelper();

            Log.Info($"Log in to the email");
            _startPage = new StartPage();
            _loginPage = _startPage.ClickLogin();
            _homePage = _loginPage.Login(user);
        }

        [TearDown]
        public void TearDown()
        {
            Log.Info($"{TestContext.CurrentContext.Test.Name} - {TestContext.CurrentContext.Result.Outcome}");
            Browser.TakeScreenshotOfFailure();

            Log.Info("Log out");
            _userMenuPage = _homePage.OpenUserMenu();
            _userMenuPage.Logoff();

            Browser.Quit();
        }
    }
}