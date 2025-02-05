using System;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class DataConverterService : IDataConverterService
	{
		public NetworkData ConvertToNetworkData<T>(T fromEntity) where T : class
		{
            NetworkData result = new NetworkData();

            switch (fromEntity.GetType().Name)
			{
				case "Message":
                    Message message = fromEntity as Message;
                    result.DestinationIP = "127.0.0.1"; //message.Sender.GetIpFromService()
                    result.DestinationPort = 5000;
                    result.Data = new byte[50];
                    return result;
                default:
					return result;
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
