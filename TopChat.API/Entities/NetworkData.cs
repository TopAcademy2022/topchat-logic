namespace TopChat.API.Entities
{
	public class NetworkData
	{
		public int Id { get; set; }

		public string DestinationIP { get; set; } = null!;

		public int DestinationPort { get; set; }

		public byte[] Data { get; set; } = null!;
	}
}
