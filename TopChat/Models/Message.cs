using System;

namespace TopChat.Models
{
	public class Message
	{
		public int Id { get; set; }

		public Media MediaData { get; set; } = null!;

		public User? Sender { get; set; } 

		public User? Recipient { get; set; }

		public DateTime DateTime { get; set; }
	}
}
