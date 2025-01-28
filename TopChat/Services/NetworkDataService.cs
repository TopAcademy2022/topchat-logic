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

        public NetworkData CreateRequest(object entity, bool sendType)
		{
			return new NetworkData();
		}
    }
}
