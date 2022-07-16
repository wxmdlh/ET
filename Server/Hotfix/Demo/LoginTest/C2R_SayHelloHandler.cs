namespace ET
{
    public class C2R_SayHelloHandler: AMHandler<C2R_SayHello>
    {
        protected override async ETTask Run(Session session, C2R_SayHello message)
        {
            Log.Debug(message.Hello);
            Log.Debug("客户端向服务器端发送消息成功（无需从服务器端回应）");

            //服务器主动发送
            session.Send(new R2C_SayGoodBye() { GoodBye = "服务器主动发送消息: goodBye" });

            await ETTask.CompletedTask;
        }
    }
}