using System;

namespace ET
{
    public static class SceneChangeHelper
    {
        // 场景切换协程
        public static async ETTask SceneChangeTo(Scene zoneScene, string sceneName, long sceneInstanceId)
        {
            zoneScene.RemoveComponent<AIComponent>();

            CurrentScenesComponent currentScenesComponent = zoneScene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = SceneFactory.CreateCurrentScene(sceneInstanceId, zoneScene.Zone, sceneName, currentScenesComponent);
            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();

            // 可以订阅这个事件中创建Loading界面
            Game.EventSystem.Publish(new EventType.SceneChangeStart() { ZoneScene = zoneScene });

            // 等待CreateMyUnit的消息
            WaitType.Wait_CreateMyUnit waitCreateMyUnit = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_CreateMyUnit>();
            M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            unitComponent.Add(unit);

            zoneScene.RemoveComponent<AIComponent>();

            Game.EventSystem.Publish(new EventType.SceneChangeFinish() { ZoneScene = zoneScene, CurrentScene = currentScene });

            // 通知等待场景切换的协程
            zoneScene.GetComponent<ObjectWait>().Notify(new WaitType.Wait_SceneChangeFinish());

            //ActorLocation 消息的发送练习
            
            // try
            // {
            //     Session session = zoneScene.GetComponent<SessionComponent>().Session;
            //     var m2CTestActorLocationResponse =
            //             (M2C_TestActorLocationResponse) await session.Call(
            //                 new C2M_TestActorLocationRequest() { Content = "从客户端向Map端发送有返回的消息: 11111" });
            //     Log.Debug("客户端发送有返回的消息，发送完毕");
            //     session.Send(new C2M_TestActorLocationMessage() { Content = "客户端向服务器端发送没有返回值的消息：22222" });
            //     Log.Debug("客户端向服务器端发送没有返回值的消息，发送完毕");
            // }
            // catch (Exception e)
            // {
            //     Log.Debug(e.ToString());
            // }
        }
    }
}