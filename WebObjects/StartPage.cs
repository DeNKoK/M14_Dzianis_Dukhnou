using log4net;
using OpenQA.Selenium;

namespace M11_Dzianis_Dukhnou.WebObjects
{
    public class StartPage : BasePage
    {
        private static readonly By StartPageLocator = By.CssSelector(".button2_theme_mail-white");

        private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StartPage() : base(StartPageLocator, "Start Page")
        {
            Log.Info($"The {_title} is open");
        }

        private readonly BaseElement _loginButton = new BaseElement(By.CssSelector(".button2_theme_mail-white"));

        public LoginPage ClickLogin()
        {
            _loginButton.Click();

            return new LoginPage();
        }
    }
}