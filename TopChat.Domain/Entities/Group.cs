using System.Collections.Generic;

namespace TopChat.Domain.Entities
{
	public class Group
	{
		public string Name { get; set; } = null!;

		public List<User> Users { get; set; } = null!;
    }
}
