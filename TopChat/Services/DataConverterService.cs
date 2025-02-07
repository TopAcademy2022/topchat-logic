using System.Text;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class DataConverterService : IDataConverterService
	{
		private const ushort _DESTINATION_PORT = 5000;

		public NetworkData ConvertToNetworkData<T>(T fromEntity) where T : class
		{
			NetworkData result = new NetworkData();

			switch (fromEntity)
			{
				case Message:
					Message message = fromEntity as Message;
					result.DestinationIP = UserServes.GetIpAddress(message.Sender);
					result.DestinationPort = _DESTINATION_PORT;
					result.Data = ConvertToData(message);
					return result;
				case User:
					User user = fromEntity as User;
					result.DestinationIP = UserServes.GetIpAddress(user);
					result.DestinationPort = _DESTINATION_PORT;
					result.Data = ConvertToData(user);
					return result;
				case Group:
					Group group = fromEntity as Group;
					result.DestinationIP = UserServes.GetIpAddress(group.Users.First()); ///< Default first user ip
					result.DestinationPort = _DESTINATION_PORT;
					result.Data = ConvertToData(group);
					return result;
				case Media:
					Media media = fromEntity as Media;
					result.DestinationIP = "127.0.0.1"; ///< Default for Media
					result.DestinationPort = _DESTINATION_PORT;
					result.Data = ConvertToData(media);
					return result;
				default:
					return result;
			}
		}

		public T ConvertFromNetworkData<T>(NetworkData fromEntity) where T : class
		{
			string dataString = Encoding.UTF8.GetString(fromEntity.Data);
			string[] parts = dataString.Split('|');

			switch (parts[0])
			{
				case "Message":
					Message message = new Message();
					message.Sender = new User { Login = parts[1] };
					message.MediaData = new Media { Text = parts[2] };
					return message as T;
				case "User":
					User user = new User();
					user.Login = parts[1];
					user.Password = parts[2];
					return user as T;
				case "Group":
					Group group = new Group();
					group.Name = parts[1];
					group.Users = parts[2].Split(',').Select(login => new User { Login = login }).ToList();
					return group as T;
				case "Media":
					Media media = new Media();
					media.Text = parts[2];
					return media as T;
				default:
					throw new NotSupportedException($"Unknown type: {parts[0]}");
			}
		}

		private byte[] ConvertToData<T>(T entity) where T : class
		{
			string dataString;

			switch (entity)
			{
				case Message message:
					dataString = $"Message|{message.Sender.Login}|{message.MediaData.Text}";
					break;
				case User user:
					dataString = $"User|{user.Login}|{user.Password}";
					break;
				case Group group:
					dataString = $"Group|{group.Name}|{string.Join(",", group.Users.Select(a => a.Login))}";
					break;
				case Media media:
					dataString = $"Media|{media.Text.Length}|{media.Text}";
					break;
				default:
					throw new NotSupportedException($"Type {entity.GetType().Name} is not supported.");
			}

			return Encoding.UTF8.GetBytes(dataString);
		}
	}
}