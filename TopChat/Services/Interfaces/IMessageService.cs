using TopChat.Models;

namespace TopChat.Services.Interfaces
{
    public interface IMessageService
    {
        public bool AddMessage(Message message);

        public List<Message> GetMessages(User sender);
    }
}
