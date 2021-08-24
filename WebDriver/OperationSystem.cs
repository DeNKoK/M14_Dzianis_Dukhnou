namespace M11_Dzianis_Dukhnou.WebDriver
{
    public class OperationSystem
    {
        private static OperationSystem _instance;

        public string Name { get; private set; }

        private OperationSystem(string name)
        {
            Name = name;
        }

        public static OperationSystem GetInstance(string name)
        {
            if (_instance == null)
                _instance = new OperationSystem(name);
            return _instance;
        }
    }
}