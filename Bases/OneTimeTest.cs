using log4net;
using M11_Dzianis_Dukhnou.Utilities;
using NUnit.Framework;

namespace M11_Dzianis_Dukhnou
{

    [SetUpFixture]
    public class OneTimeTest
    {
        private static ILog Log;

        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Log.Info("!!!Execution of test(s) have been started!!!");
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            Log.Info($"!!!Execution of test(s) have been finished!!!");
            ReportConverter.GetHtmlReportFromTrx();
        }
    }
}
