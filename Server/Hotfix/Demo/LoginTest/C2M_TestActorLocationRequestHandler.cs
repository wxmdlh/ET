using System;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_TestActorLocationRequestHandler: AMActorLocationRpcHandler<Unit, C2M_TestActorLocationRequest, M2C_TestActorLocationResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TestActorLocationRequest request, M2C_TestActorLocationResponse response, Action reply)
        {
            Log.Debug("客户端发到服务器端的消息，在服务器端处理时显示：" + request.Content);
            response.Content = "aaaaaaa";

            reply();
            await ETTask.CompletedTask;
        }
    }
}