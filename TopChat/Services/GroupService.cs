using System.Net.Sockets;
using System.Net;
using System.Text;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
    public class GroupService : IGroupService
    {
        private readonly List<Group> _AllGroups = new List<Group>();
        private int _CURRENT_GROUP_ID = 1;

        public Group CreateGroup(string name)
        {
            var group = new Group
            {
                Id = _CURRENT_GROUP_ID++,
                Name = name,
                Users = new List<User>()
            };
            _AllGroups.Add(group);
            return group;
        }

        public void AddUserToGroup(Group group, User user)
        {
            if (!group.Users.Any(a => a.Id == user.Id))
            {
                group.Users.Add(user);
                Console.WriteLine($"{user.Login} joined {group.Name}!");
            }
            else
            {
                Console.WriteLine($"{user.Login} is already in the group {group.Name}.");
            }
        }

        public void SendMessageToGroup(Group group, string messageText, User sender)
        {
            foreach (User user in group.Users)
            {
                if (user.Id != sender.Id)
                {
                    SendUnicastMessage(sender.IP, 12345, messageText, sender.Login);
                }
            }
        }

        public void SendUnicastMessage(string destinationIP, int destinationPort, string messageText, string senderLogin)
        {
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    var message = $"{senderLogin}: {messageText}";
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(destinationIP), destinationPort);
                    udpClient.Send(data, data.Length, endPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send message to {destinationIP}:{destinationPort}. Error: {ex.Message}");
            }
        }
    }
}
