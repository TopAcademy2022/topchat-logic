using System.Net;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using TopChat.Services;
using TopChat.Services.Interfaces;

namespace TopChat.Tests
{
	public class TopChatTests
	{
		[Fact]
		public void SqliteConnectionTest()
		{
			SqliteConnection connection = new SqliteConnection();

			Assert.True(connection.Database.CanConnect());
		}

		//[Fact]
		//public void MongoDBConnectionTest()
		//{
		//	MongoDBConnection connection = new MongoDBConnection();
		//	Assert.True(connection.Database.CanConnect());
		//}
    
    [Fact]
    public void SetDestinationUdpTest()
    {
        ConnectionProviderUdp connectionProviderUdp = new ConnectionProviderUdp();
        Assert.True(connectionProviderUdp.SetDestination("127.0.0.1", 12345));

        Assert.True(connectionProviderUdp.GetIPEndPoint().Address.ToString() == "127.0.0.1");
        Assert.True(connectionProviderUdp.GetIPEndPoint().Port == 12345);
    }

    [Fact]
    public void SendUdpTest()
    {
        using UdpClient receiver = new UdpClient(12345);
        receiver.Client.ReceiveTimeout = 1000;

        ConnectionProviderUdp sender = new ConnectionProviderUdp();
        Assert.True(sender.SetDestination("127.0.0.1", 12345));

        byte[] testData = { 1,2,3,4,5 };
        Assert.True(sender.Send(testData));

        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
        byte[] receivedData = receiver.Receive(ref remoteEP);

        Assert.Equal(testData, receivedData);
    }
	}
}