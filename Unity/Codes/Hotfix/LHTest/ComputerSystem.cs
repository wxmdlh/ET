namespace ET
{
    public static class ComputerSystem
    {
        public static void Start(this Computer self)
        {
            Log.Debug($"computer Start!!!!!!!!");
            self.GetComponent<PCCaseComponent>().Start();
            self.GetComponent<PCMonitorsComponent>().Start();
            
        }
    }
}