

using UnityEngine;

namespace ET
{
	public class AppStartInitFinish_CreateLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			await UIHelper.Create(args.ZoneScene, UIType.UILogin, UILayer.Mid);

			Computer computer = args.ZoneScene.AddChild<Computer>();
			computer.AddComponent<PCCaseComponent>();
			computer.AddComponent<PCMonitorsComponent>();
			computer.AddComponent<PCKeyBoardComponent>();
			
			computer.Start();

			await TimerComponent.Instance.WaitAsync(3000);
			computer.Dispose();

			Log.Debug("aaaaaaaaaaaaaaaaaaaaa"); 
			await TestAsync();
			Log.Debug("bbbbbbbbbbbbbbbbbbbbb");
			
			//通过ID获取数据
			UnitConfig unitConfig = UnitConfigCategory.Instance.Get(1001);
			Log.Debug(unitConfig.Name);
			//获取所有数据
			var unitConfigs = UnitConfigCategory.Instance.GetAll();
			foreach (var temp in unitConfigs.Values)
			{
				Log.Debug(temp.Name);
				Log.Debug(temp.TestValue.ToString());
				for (int i = 0; i < temp.Direct.Length; i++)
				{
					Log.Debug(temp.Direct[i].ToString());
				}
			}
			//扩展分布类，自定义方法
			UnitConfig heightConfig = UnitConfigCategory.Instance.GetUnitConfigByHeight(178);
			Log.Debug(heightConfig.Name);

		}

		private async ETTask TestAsync()
		{
			Log.Debug("111111111111111111111");
			await TimerComponent.Instance.WaitAsync(1000);
			Log.Debug("22222222222222222222222");
		}
	}
}
