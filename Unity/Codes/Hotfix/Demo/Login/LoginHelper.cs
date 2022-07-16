using System;


namespace ET
{
    public static class LoginHelper
    {
        public static async ETTask Login(Scene zoneScene, string address, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                R2C_Login r2CLogin;//  电话返回的消息
                Session session = null;//ET中管理socket  作用类似于一个电话
                try
                {
                    session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));//1.请求分配网关
                    {
                        r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = password });//使用电话，请求服务器端的账户和密码，异步等待直到返回消息
                    }
                }
                finally
                {
                    session?.Dispose();//得到返回的消息后，把电话挂断
                }

                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));//2.创建一个gate网关
                gateSession.AddComponent<PingComponent>();
                zoneScene.AddComponent<SessionComponent>().Session = gateSession;
				//3.让gate网关和客户端进行连接
                G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

                Log.Debug("登陆gate成功!");

                await Game.EventSystem.PublishAsync(new EventType.LoginFinish() {ZoneScene = zoneScene});
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static async ETTask LoginTest(Scene zoneScene, string address)
        {
            try
            {
                Session session = null;
                R2C_LoginTest r2CLoginTest = null;
                try
                {
                    session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                    {
                        r2CLoginTest = (R2C_LoginTest) await session.Call(new C2R_LoginTest() { Account = "账号", Password = "密码" });
                        Log.Debug(r2CLoginTest.Key);
                        session.Send(new C2R_SayHello(){Hello = "你好世界"});
                        await TimerComponent.Instance.WaitAsync(2000);
                    }
                }
                finally
                {
                    session?.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            await ETTask.CompletedTask;
        }
    }
}