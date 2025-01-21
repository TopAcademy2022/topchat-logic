using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TopChat
{
	public class Message
	{
		private const ushort _DATA_SIZE = 1024;

		private byte[] _data;

		private delegate void AddMessage();

		private delegate void PrintMessage();

		private event AddMessage _DataChanged;

		private event PrintMessage _WriteStop;

		private string _userLogin;

		private IPEndPoint _destinationIP;

		Socket _listenSocket;

		private List<string> _messageList;

		public Message(Socket listenSocket, string userLogin, IPEndPoint destinationIP)
		{
			this._data = new byte[_DATA_SIZE];
			this._DataChanged += this.AddToMessages;

			this._listenSocket = listenSocket;

			this._userLogin = userLogin;
			this._destinationIP = destinationIP;

			this._messageList = new List<string>();
			this._WriteStop += this.PrintAllMessages;
		}

		private async Task Listen()
		{
			int size = await this._listenSocket.ReceiveAsync(this._data);

			if (size > 0)
			{
				this._DataChanged?.Invoke();
			}
		}

		public void Write()
		{
			Console.WriteLine("Введите сообщение для отправки:");
			string data = Console.ReadLine();
			this._listenSocket.SendTo(Encoding.ASCII.GetBytes(
				$"{DateTime.Now}.{this._userLogin}: {data}"),
				this._destinationIP);

			this._WriteStop?.Invoke();
		}

		public void StartListen()
		{
			Task.Run(() => this.Listen());
		}

		private void AddToMessages()
		{
			this._messageList.Add(this.ToString());
		}

		private void PrintAllMessages()
		{
			Thread.Sleep(1000);
			foreach (string message in this._messageList)
			{
				Console.WriteLine($"Вам отправлено: {message}");
			}

			this._messageList.Clear();
		}

		public override string ToString()
		{
			return Encoding.UTF8.GetString(this._data);
		}
	}
}
