using System.Net;
using System.Net.Sockets;
using System.Text;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class ConnectionProviderUdp : IConnectionProvider
	{
		private UdpClient _udpClient;

		private IPEndPoint _IPEndPoint;

		public ConnectionProviderUdp()
		{
			this._udpClient = new UdpClient();
		}

		public bool SetDestination(string destinationIP, int destinationPort)
		{
			this._IPEndPoint = new IPEndPoint(IPAddress.Parse(destinationIP), destinationPort);
			return true;
		}

		public bool Send(byte[] data)
		{
			this._udpClient.Send(data, this._IPEndPoint);
			return true;
		}

        public void StartReceiving(User user)
        {
            UdpClient udpClient = new UdpClient
            {
                Client = { ExclusiveAddressUse = false }
            };
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 12345));

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 12345);

            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                        string receivedMessage = Encoding.UTF8.GetString(receivedData);

                        Console.WriteLine($"{receivedMessage}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error while receiving message for {user.Login}: {ex.Message}");
                    }
                }
            });
        }
    }
}
