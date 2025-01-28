using TopChat.Models;

namespace TopChat.Services.Interfaces
{
	public interface IDataConverterService
	{
		public NetworkData ConvertToNetworkData<T>(T fromEntity) where T : class;

        public T ConvertFromNetworkData<T>(NetworkData fromEntity) where T : class;
    }
}
