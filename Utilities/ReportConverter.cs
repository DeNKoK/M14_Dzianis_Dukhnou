using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace M11_Dzianis_Dukhnou.Utilities
{
    public static class ReportConverter
    {
        public static void GetHtmlReportFromTrx()
        {
            string solutionLocation = Path.GetDirectoryName(Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName);
            string fullName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\TrxerConsole.exe";
            
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = fullName;
            info.Arguments = $@"{solutionLocation}\TestResults\TestResult.trx {solutionLocation}\TestResults\";
            Process.Start(info);
        }
    }
}
