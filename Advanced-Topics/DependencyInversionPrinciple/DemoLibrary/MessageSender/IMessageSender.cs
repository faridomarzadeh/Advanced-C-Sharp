namespace DemoLibrary.MessageSender
{
    public interface IMessageSender
    {
        void SendMessage(IPerson owner, string message);
    }
}