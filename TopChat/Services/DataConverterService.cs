using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class DataConverterService : IDataConverterService
	{
		public NetworkData Convert<T>(T fromEntity, NetworkData toEntity) where T : class
		{
			switch (fromEntity.GetType().Name)
			{
				default:
					return new NetworkData();
			}
		}
	}
}
