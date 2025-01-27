using System.Net.Sockets;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
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

        public void JoinGroup(string multicastAddress, int port)
        {
            UdpClient udpClient = new UdpClient();
            IPAddress ipAddress = IPAddress.Parse(multicastAddress);

            // Allow multiple clients to bind to the same port
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));

            udpClient.JoinMulticastGroup(ipAddress);
        }


        public void StartReceiving(User user, int port)
        {
            UdpClient udpClient = new UdpClient();

            // Enable socket option to allow multiple clients to bind to the same port
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, port);

            udpClient.Client.Bind(localEndPoint);

            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        // Receive the multicast message
                        byte[] receivedData = udpClient.Receive(ref localEndPoint);
                        string message = Encoding.UTF8.GetString(receivedData);

                        Console.WriteLine($"{user.Login} received: {message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error while receiving: {ex.Message}");
                    }
                }
            });
        }

        public bool SendToGroup(Group group, string messageText, User sender)
		{
			NetworkData networkData = new NetworkData
			{
				DestinationIP = "224.0.0.1", ///< Multicast group ip address
				DestinationPort = 12345, ///< Port for group
				Data = Encoding.UTF8.GetBytes(messageText)
			};

			this._connectionProvider.Send(networkData.Data); ///< Send to multicast address
		
			return true;
		}
	}
}
