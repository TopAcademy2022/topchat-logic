using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TopChat.Services.Interfaces
{
	public interface IConnectionProvider
	{
		public bool SetDestination(string destinationIP, int destinationPort);

		public bool Send(byte[] data);

		public Task<UdpReceiveResult> ReceiveAsync(IPEndPoint? iPEndPoint = null);
	}
}
