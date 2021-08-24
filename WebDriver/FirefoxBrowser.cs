using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace M11_Dzianis_Dukhnou.WebDriver
{
    public class FirefoxBrowser : IBrowser
    {
        private IWebDriver _driver = null;
        private readonly int _timeOutSec;

        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    var service = FirefoxDriverService.CreateDefaultService();
                    var options = new FirefoxOptions();
                    _driver = new FirefoxDriver
                        (
                        service,
                        options,
                        TimeSpan.FromSeconds(TimeOutSec)
                        );
                }

                return _driver;
            }
        }

        public int TimeOutSec
        {
            get
            {
                return _timeOutSec;
            }
        }

        public FirefoxBrowser(int timeOut)
        {
            this._timeOutSec = timeOut;
        }
    }
}
