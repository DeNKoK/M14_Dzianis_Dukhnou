﻿using M11_Dzianis_Dukhnou.WebDriver;

namespace M11_Dzianis_Dukhnou.WebElements
{
    public class JsDecorator : ElementDecorator
    {
        public JsDecorator(BaseElement webElement) : base(webElement, webElement.Locator) { }

        public override void Click()
        {
            WaitForIsVisible();
            jsExecutor.ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(Locator));
        }
    }
}