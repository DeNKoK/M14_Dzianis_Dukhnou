using M11_Dzianis_Dukhnou.WebElements;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace M11_Dzianis_Dukhnou
{
    public abstract class Element : IWebElementBase
    {
        public By Locator { get; protected set; }

        protected Element(By locator)
        {
            this.Locator = locator;
        }

        public abstract void WaitForIsVisible();

        public abstract bool IsElementDisplayed();

        public abstract string GetText();

        public abstract void Click();

        public abstract void RightClick(IWebElement letter);

        public abstract ReadOnlyCollection<IWebElement> GetElements();

        public abstract void SendKeys(string text);
    }
}