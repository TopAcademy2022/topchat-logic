namespace TopChat.Models
{
	public class Message
	{
		public int Id { get; set; }

		public string Text { get; set; } = null!;

		public User Sender { get; set; } = null!;

		public User Recipient { get; set; } = null!;

		public DateTime DateTime { get; set; }

		public Group RecipientGroup { get; set; } = null!;

		public bool IsGroupMessage { get; set; }
	}
}
