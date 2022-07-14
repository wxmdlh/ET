using ET.EventType;

namespace ET.Demo.Computer.Event
{
    public class InstallComputer_AddComponent:AEvent<EventType.InstallComputer>
    {
        protected async override ETTask Run(InstallComputer arg)
        {
            await TimerComponent.Instance.WaitAsync(1000);
            
            ET.Computer computer = arg.computer;
            computer.AddComponent<PCCaseComponent>();
            computer.AddComponent<PCMonitorsComponent>();
            computer.AddComponent<PCKeyBoardComponent>();

            await ETTask.CompletedTask;
        }
    }
}