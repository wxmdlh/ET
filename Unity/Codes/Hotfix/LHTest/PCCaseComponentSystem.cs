namespace ET
{
    public static class PCCaseComponentSystem
    {
        public static void Start(this PCCaseComponent self)
        {
            Log.Debug(self.ToString());
            Log.Debug("打开电源!!!!!!");
        }
    }
}