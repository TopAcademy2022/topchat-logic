using TopChat.Models;

namespace TopChat.Services.Interfaces
{
    public interface IGroupService
    {
        public Group CreateGroup(string name);

        public void AddUserToGroup(Group group, User userName);

        public void SendMessageToGroup(Group group, string messageText, User sender);

        public void SendUnicastMessage(string destinationIP, int destinationPort, string messageText, string senderLogin);
    }
}
