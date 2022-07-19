namespace ET
{
    public class M2C_TestActorMessageHandler:AMHandler<M2C_TestActorMessage>
    {
        protected override async ETTask Run(Session session, M2C_TestActorMessage message)
        {
            Log.Warning("服务器端向客户端被动发送的消息"+message.Content);
            await ETTask.CompletedTask;
        }
    }
}