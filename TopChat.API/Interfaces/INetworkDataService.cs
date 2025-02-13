using TopChat.API.Entities;

namespace TopChat.API.Interfaces
{
    public interface INetworkDataService
    {
        public NetworkData Send(NetworkData request);

        public NetworkData Get(NetworkData request);

        public NetworkData ConvertToNetworkData<T>(T fromEntity, SendType sendType) where T : class;

        public T ConvertFromNetworkData<T>(NetworkData networkData) where T : class;
    }
}
