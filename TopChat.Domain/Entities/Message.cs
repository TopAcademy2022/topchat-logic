using System;

namespace TopChat.Domain.Entities
{
    public class Message
	{
		public Media MediaData { get; set; } = null!;

		public User Sender { get; set; } = null!;

		public User Recipient { get; set; } = null!;

		public DateTime DateTime { get; set; }
	}
}
