using System.Text;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class NetworkDataService : INetworkDataService
	{
		private IConnectionProvider _connectionProvider;

		public NetworkDataService(IConnectionProvider connectionProvider)
		{
			this._connectionProvider = connectionProvider;
		}

		public bool Send(NetworkData networkData)
		{
			this._connectionProvider.SetDestination(networkData.DestinationIP, networkData.DestinationPort);
			return this._connectionProvider.Send(networkData.Data);
		}

		public NetworkData Get(NetworkData request)
		{
			return new NetworkData();
		}

		public NetworkData CreateRequest(User entity, SendType sendType)
		{
			//UdpClient u = new UdpClient(5000);

			//UdpReceiveResult receivedResults = u.ReceiveAsync().Result;
			//byte[] receivedBytes = receivedResults.Buffer;
			//IPEndPoint remoteEndPoint = receivedResults.RemoteEndPoint;

			NetworkData networkData = new NetworkData();

			switch (sendType)
			{
				case SendType.Create:

					string data = $"get|User|{entity.Login}|{entity.Password}";
					networkData.Data = Encoding.UTF8.GetBytes(data);

					break;
				case SendType.Delete:

					break;
				case SendType.Update:

					break;
				case SendType.Read:

					break;
			}

			return networkData;
		}
	}
}
