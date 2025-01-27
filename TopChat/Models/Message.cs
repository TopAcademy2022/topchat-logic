using System.Net.Sockets;

namespace TopChat.Models
{
	public class Message
	{
		public int Id { get; set; }

		public string Text { get; set; } = null!;

        public NetworkStream stream { get; set; } = null!;

        public User Sender { get; set; } = null!;

		public User Recipient { get; set; } = null!;

		public DateTime DateTime { get; set; }
	}
}
