namespace DemoLibrary.MessageSender
{
    public class Emailer : IMessageSender
    {
        public void SendMessage(IPerson owner, string message)
        {
            Console.WriteLine($"simulating sending \"{message}\" to {owner.EmailAddress}");
        }
    }
}
