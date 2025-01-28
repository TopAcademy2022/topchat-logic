using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class DataConverterService : IDataConverterService
	{
		public NetworkData ConvertToNetworkData<T>(T fromEntity) where T : class
		{
			switch (fromEntity.GetType().Name)
			{
				default:
					return new NetworkData();
			}
		}

        public T ConvertFromNetworkData<T>(NetworkData fromEntity) where T : class
		{
            Type type = typeof(T);
            switch (type.Name)
            {
                default:
                    return new Message() as T;
            }
        }
    }
}
