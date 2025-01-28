using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class NetworkDataService
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
	}
}
