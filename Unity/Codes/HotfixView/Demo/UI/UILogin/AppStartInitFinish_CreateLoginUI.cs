

namespace ET
{
	public class AppStartInitFinish_CreateLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			await UIHelper.Create(args.ZoneScene, UIType.UILogin, UILayer.Mid);

			// Computer computer = args.ZoneScene.AddChild<Computer>();
			// computer.AddComponent<PCCaseComponent>();
			// computer.AddComponent<PCMonitorsComponent>();
			// computer.AddComponent<PCKeyBoardComponent>();
			//
			// computer.Start();

			Log.Debug("aaaaaaaaaaaaaaaaaaaaa"); 
			await TestAsync();
			Log.Debug("bbbbbbbbbbbbbbbbbbbbb");
		}

		private async ETTask TestAsync()
		{
			Log.Debug("111111111111111111111");
			await TimerComponent.Instance.WaitAsync(1000);
			Log.Debug("22222222222222222222222");
		}
	}
}
