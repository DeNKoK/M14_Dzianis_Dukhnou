using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using M11_Dzianis_Dukhnou.WebDriver;
using M11_Dzianis_Dukhnou.WebElements;
using log4net;

namespace M11_Dzianis_Dukhnou
{
    public class BaseElement : Element
    {
        public By Locator { get; protected set; }
        protected Actions action = new Actions(Browser.GetDriver());
        protected IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Browser.GetDriver();
        protected static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseElement(By locator) : base(locator)
        {
            Locator = locator;
        }

        public override void WaitForIsVisible()
        {
            Log.Debug($"Waiting for the element: {Locator}");
            new WebDriverWait
                (
                    Browser.GetDriver(),
                    TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(Locator)
                );
        }

        public override bool IsElementDisplayed()
        {
            try
            {
                WaitForIsVisible();

                return true;
            }
            catch (Exception)
            {
                Log.Error($"The element {Locator} is not displayed");
                return false;
            }
        }

        public override string GetText()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElement(Locator).Text;
        }

        public override void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(Locator).Click();
        }

        public override void RightClick(IWebElement letter)
        {
            WaitForIsVisible();
            action.ContextClick(letter).Build().Perform();
        }

        public override ReadOnlyCollection<IWebElement> GetElements()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElements(Locator);
        }

        public override void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(Locator).SendKeys(text);
        }
    }
}