using MySupermarket.Services.Interfaces;

namespace MySupermarket.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
