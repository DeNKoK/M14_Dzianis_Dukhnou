using OpenQA.Selenium;

namespace M11_Dzianis_Dukhnou.WebDriver
{
    public class BrowserFactory
    {

        public static IWebDriver GetDriver(BrowserType type, Computer computer, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        driver = new ChromeBrowser(timeOutSec).Driver;
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        driver = new RemoteChromeBrowser(computer, timeOutSec).Driver;
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        driver = new FirefoxBrowser(timeOutSec).Driver;
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        driver = new RemoteFirefoxBrowser(timeOutSec).Driver;
                        break;
                    }
            }

            return driver;
        }
    }
}