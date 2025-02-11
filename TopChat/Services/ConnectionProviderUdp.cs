using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class ConnectionProviderUdp : IConnectionProvider
	{
		private UdpClient _udpClient;

		private IPEndPoint _IPEndPoint;

		public ConnectionProviderUdp()
		{
			this._udpClient = new UdpClient();
		}

		public bool SetDestination(string destinationIP, int destinationPort)
		{
			this._IPEndPoint = new IPEndPoint(IPAddress.Parse(destinationIP), destinationPort);
			return true;
		}

		public bool Send(byte[] data)
		{
			//this._udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			this._udpClient.Send(data, data.Length, this._IPEndPoint);

			return true;
		}

		public async Task<UdpReceiveResult> ReceiveAsync(IPEndPoint? iPEndPoint = null)
		{
			if (iPEndPoint == null)
			{
				iPEndPoint = this._IPEndPoint; 
			}

			this._udpClient.Connect(this._IPEndPoint);

			return await _udpClient.ReceiveAsync();
		}

		public IPEndPoint GetIPEndPoint()
		{
			return this._IPEndPoint;
		}
	}
}
