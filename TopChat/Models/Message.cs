namespace TopChat.Models
{
	public class Message
	{
		public int Id { get; set; }

		public MediaData MediaData { get; set; } = null!;

		public User Sender { get; set; } = null!;

		public User Recipient { get; set; } = null!;

		public DateTime DateTime { get; set; }
	}
}
