using TopChat.Models;

namespace TopChat.Services.Interfaces
{
	public interface IDataConverterService
	{
		public NetworkData Convert<T>(T fromEntity, NetworkData toEntity) where T : class;
	}
}
