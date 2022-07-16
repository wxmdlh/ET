using System;

namespace ET
{
    /// <summary>
    /// 从客户端向服务器端发送的消息的内容 
    /// </summary>
    public class C2R_LoginTestHandler: AMRpcHandler<C2R_LoginTest, R2C_LoginTest>
    {
        protected override async ETTask Run(Session session, C2R_LoginTest request, R2C_LoginTest response, Action reply)
        {
            response.Key = "向服务器发送一条消息:111111111111";
            reply();
            Log.Debug("从客户端向服务器端发送的消息的内容 ");

            await ETTask.CompletedTask;
        }
    }
}