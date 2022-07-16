

using UnityEngine;

namespace ET
{
	public class AppStartInitFinish_CreateLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		protected override async ETTask Run(EventType.AppStartInitFinish args)
		{
			await UIHelper.Create(args.ZoneScene, UIType.UILogin, UILayer.Mid);

			// Computer computer = args.ZoneScene.AddChild<Computer>();
			
			// Game.EventSystem.Publish(new EventType.InstallComputer(){computer = computer});
			// Game.EventSystem.PublishAsync(new EventType.InstallComputer(){computer = computer}).Coroutine();
			// await Game.EventSystem.PublishAsync(new EventType.InstallComputer(){computer = computer});
			// computer.Start();
			
			// computer.AddComponent<PCCaseComponent>();
			// computer.AddComponent<PCMonitorsComponent>();
			// computer.AddComponent<PCKeyBoardComponent>();
			//
			// computer.Start();
			//
			// await TimerComponent.Instance.WaitAsync(3000);
			// computer.Dispose();
			//
			// Log.Debug("aaaaaaaaaaaaaaaaaaaaa"); 
			// await TestAsync();
			// Log.Debug("bbbbbbbbbbbbbbbbbbbbb");
			//
			// //通过ID获取数据
			// UnitConfig unitConfig = UnitConfigCategory.Instance.Get(1001);
			// Log.Debug(unitConfig.Name);
			// //获取所有数据
			// var unitConfigs = UnitConfigCategory.Instance.GetAll();
			// foreach (var temp in unitConfigs.Values)
			// {
			// 	Log.Debug(temp.Name);
			// 	Log.Debug(temp.TestValue.ToString());
			// 	for (int i = 0; i < temp.Direct.Length; i++)
			// 	{
			// 		Log.Debug(temp.Direct[i].ToString());
			// 	}
			// }
			// //扩展分布类，自定义方法
			// UnitConfig heightConfig = UnitConfigCategory.Instance.GetUnitConfigByHeight(178);
			// Log.Debug(heightConfig.Name);

			//ETTask相关学习
			// Log.Debug("aaaaaaaaaaaaaaa");
			// // await TestAsync();
			// // this.TestAsync().Coroutine();
			// ETCancellationToken cancellationToken = new ETCancellationToken();
			// TestCancelAsync(cancellationToken).Coroutine();
			// Log.Debug("bbbbbbbbbbbbbbbb");
			// cancellationToken.Cancel();
		}

		private async ETTask TestAsync()
		{
			Log.Debug("111111111111111111111");
			await TimerComponent.Instance.WaitAsync(10000);
			Log.Debug("22222222222222222222222");
		}

		public async ETTask TestCancelAsync(ETCancellationToken token)
		{
			Log.Debug("开始游戏");

			var ret = await TimerComponent.Instance.WaitAsync(3000, token);

			if (ret)
			{
				Log.Debug("游戏结束");
			}
			else
			{
				Log.Debug("游戏停止");
			}
		}
	}
}
