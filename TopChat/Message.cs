using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TopChat
{
	public class Message
	{
		private const ushort _DATA_SIZE = 1024;

		private static string _userLogin;

		private static IPEndPoint _destinationIP;

		private static Socket _listenSocket;

		private static List<string> _messageList;

		public Message(Socket listenSocket, string userLogin, IPEndPoint destinationIP)
		{
			_listenSocket = listenSocket;

			_userLogin = userLogin;
			_destinationIP = destinationIP;

			_messageList = new List<string>();
		}

		public static void Listen()
		{
			while (true)
			{
				byte[] _data = new byte[_DATA_SIZE];
				int size = _listenSocket.Receive(_data);

				if (size > 0)
				{
					_messageList.Add(ToString(_data));
				}
			}
		}

		public static void Write()
		{
			while (true)
			{
				Console.WriteLine("Введите сообщение для отправки:");
				string data = Console.ReadLine();
				_listenSocket.SendTo(Encoding.ASCII.GetBytes(
					$"{DateTime.Now}.{_userLogin}: {data}"),
					_destinationIP);

				foreach (string message in _messageList)
				{
					Console.WriteLine($"Вам отправлено: {message}");
				}

				_messageList.Clear();
			}
		}

		public static string ToString(byte[] data)
		{
			return Encoding.UTF8.GetString(data);
		}
	}
}
