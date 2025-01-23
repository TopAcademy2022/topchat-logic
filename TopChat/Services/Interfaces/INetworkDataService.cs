using TopChat.Models;

namespace TopChat.Services.Interfaces
{
	public interface INetworkDataService
	{
		public bool Send(NetworkData networkData);
	}
}
