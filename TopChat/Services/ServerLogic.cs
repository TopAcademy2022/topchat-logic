using System.Net.Sockets;
using System.Net;
using System.Text;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class ServerLogic : IServerLogic
	{
		private Socket _socket;
		private IPEndPoint _ipLocalEndPoint;
		private List<byte> _messages = new List<byte>();

		public event Action<string> MessageReceived;
		public event Action ByeReceived;

		public ServerLogic()
		{
			this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			this._ipLocalEndPoint = new IPEndPoint(IPAddress.Any, 5000);
		}

		public void StartListen()
		{
			this._socket.Bind(this._ipLocalEndPoint);

			byte[] buffer = new byte[1024];
			EndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

			while (true)
			{
				int bytesReceived = this._socket.ReceiveFrom(buffer, ref clientEndpoint);
				string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

				MessageReceived?.Invoke(receivedMessage);

				if (receivedMessage == "Bye")
				{
					ByeReceived?.Invoke();
					break;
				}

				Array.Clear(buffer, 0, buffer.Length);
			}

			this._socket.Close();
		}

		public List<byte> GetListBytes()
		{
			return _messages;
		}
	}
}
