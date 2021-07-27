using M11_Dzianis_Dukhnou.Entities;
using M11_Dzianis_Dukhnou.Utilities;
using M11_Dzianis_Dukhnou.WebDriver;
using M11_Dzianis_Dukhnou.WebObjects;
using TechTalk.SpecFlow;

namespace M11_Dzianis_Dukhnou.Feature.Steps
{
    public abstract class BaseSteps
    {
        #region Variables

        protected Computer Computer;
        protected Browser Browser;
        protected StringRandomHelper randomString;
        protected readonly User user = new User(
                Configuration.UserID,
                Configuration.Password
                );
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

        #region Preconditions
        [BeforeScenario("notlogged_user")]
        public void BeforeScenarioWithOutLogin()
        {
            Computer = new Computer();
            Computer.Launch("windows");
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo();
            _startPage = new StartPage();
        }

        [BeforeScenario("logged_user")]
        public void BeforeScenarioWithLogin()
        {
            Computer = new Computer();
            Computer.Launch("windows");
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo();
            _startPage = new StartPage();
            _loginPage = _startPage.ClickLogin();
            _homePage = _loginPage.Login(user);
            randomString = new StringRandomHelper();
            letter = new Letter(
                "dzianis.dukhnou@thomsonreuters.com",
                randomString.GetRandomString(10),
                randomString.GetRandomString(50)
                );
        }

        #endregion

        #region Postconditions

        [AfterScenario("draft_tests")]
        public void AfterDraftTestRun()
        {
            _draftPage = _homePage.OpenDraftLetters();
            _draftPage.DeleteAll();
        }

        [AfterScenario("send_tests")]
        public void AfterSendTestRun()
        {
            _sentPage = _homePage.OpenSentLetters();
            _sentPage.DeleteAll();
        }

        [AfterScenario("inbox_tests")]
        public void AfterInboxTestRun()
        {
            _inboxPage = _homePage.OpenInboxLetters();
            _inboxPage.DeleteAll();
        }

        [AfterScenario("numberOfLetters_tests")]
        public void AfterNumberOfLettersTestRun()
        {
            _draftPage.DeleteAll();
        }

        [AfterScenario]
        public void AfterTestRun()
        {
            _userMenuPage = _homePage.OpenUserMenu();
            _userMenuPage.Logoff();
            Browser.Quit();
        }

        #endregion

    }
}
