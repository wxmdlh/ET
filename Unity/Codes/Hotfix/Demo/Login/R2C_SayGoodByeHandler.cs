namespace ET
{
    /// <summary>
    /// 服务器接收到客户端发来的消息后，被动发消息回客户端
    /// </summary>
    public class R2C_SayGoodByeHandler:AMHandler<R2C_SayGoodBye>
    {
        protected override async ETTask Run(Session session, R2C_SayGoodBye message)
        {
            Log.Debug(message.GoodBye);
            Log.Debug("服务器接收到客户端发来的消息后，被动发消息回客户端");
            await ETTask.CompletedTask;
        }
    }
}