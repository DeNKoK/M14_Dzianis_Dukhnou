namespace M11_Dzianis_Dukhnou.WebDriver
{
    public class Computer
    {
        public OperationSystem OperationSystem { get; set; }

        public void Launch(string osName)
        {
            OperationSystem = OperationSystem.GetInstance(osName);
        }
    }
}
