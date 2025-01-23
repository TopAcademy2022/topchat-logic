namespace TopChat.Services.Interfaces
{
	public interface IConnectionProvider
	{
		public bool SetDestination(string destinationIP, int destinationPort);

		public bool Send(byte[] data);
	}
}
