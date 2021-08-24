using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace M11_Dzianis_Dukhnou.WebDriver
{
    public class Browser
    {
        public static IWebDriver _driver;
        private static Browser _currentInstance;
        private static string _browser;
        public static Computer _currentComputer;
        public static BrowserType _currentBrowser;
        public static double _timeoutForElement;
        public static int ImplWait;
        private static ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Browser()
        {
            RunComputer();
            InitParams();
            _driver = BrowserFactory.GetDriver(_currentBrowser, _currentComputer, ImplWait);
        }

        private static void InitParams()
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            _timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out _currentBrowser);
        }

        private static void RunComputer()
        {
            _currentComputer = new Computer();
            _currentComputer.Launch(Configuration.OS);
        }

        public static Browser Instance => _currentInstance ?? (_currentInstance = new Browser());

        internal object SwitchTo()
        {
            throw new NotImplementedException();
        }

        public static void WindowMaximaze()
        {
            _driver.Manage().Window.Maximize();
        }

        public static void NavigateTo()
        {
            _driver.Navigate().GoToUrl(Configuration.StartUrl);
        }

        public static void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }

        public static void TakeScreenshotOfFailure()
        {
            string solutionLocation = Path.GetDirectoryName(Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName);

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile
                    (
                        $@"{solutionLocation}\Screenshots\{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.jpg",
                        ScreenshotImageFormat.Jpeg
                    );
                Log.Info("The screenshot of the failure has been created");

            }
        }

        public static void Quit()
        {
            _driver.Close();
            _driver.Quit();
            _currentInstance = null;
            _driver = null;
            _browser = null;
        }
    }
}