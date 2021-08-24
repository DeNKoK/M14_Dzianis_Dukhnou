using log4net;
using OpenQA.Selenium;

namespace M11_Dzianis_Dukhnou.WebObjects
{
    public class UserMenuPage : BasePage
    {
        private static readonly By StartPageLocator = By.CssSelector(".user-account_has-subname_yes");

        private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserMenuPage() : base(StartPageLocator, "UserMenu Page")
        {
            Log.Info($"The {_title} is open");
        }

        private readonly BaseElement _exitButton = new BaseElement(By.XPath("//span[text() = 'Выйти из сервисов Яндекса']"));

        public void Logoff()
        {
            _exitButton.Click();
        }
    }
}