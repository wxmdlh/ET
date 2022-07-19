namespace ET
{
    public class C2M_TestActorLocationMessageHandler: AMActorLocationHandler<Unit, C2M_TestActorLocationMessage>
    {
        protected override async ETTask Run(Unit unit, C2M_TestActorLocationMessage message)
        {
            Log.Debug("客户端向服务器端发送消息，在服务器端显示 ："+message.Content);
            MessageHelper.SendToClient(unit, new M2C_TestActorMessage() { Content = "服务器主动发送消息: bbbbbbb" });
            await ETTask.CompletedTask;
        }
    }
}