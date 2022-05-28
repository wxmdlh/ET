using System.Diagnostics;

namespace ET
{

    public class ComputerAwakeSystem: AwakeSystem<Computer>
    {
        public override void Awake(Computer self)
        {
            Log.Debug("Awake!!!!");
        }
    }

    public class ComputerUpdateSystem: UpdateSystem<Computer>
    {
        public override void Update(Computer self)
        {
            Log.Debug("Update!!!!");
        }
    }

    public class ComputerDestroySystem: DestroySystem<Computer>
    {
        public override void Destroy(Computer self)
        {
            Log.Debug("Destroy!!!!");
        }
    }
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