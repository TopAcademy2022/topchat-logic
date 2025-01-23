using Microsoft.EntityFrameworkCore;
using TopChat.Models;

namespace TopChat.Services.Interfaces
{
	public abstract class ADatabaseConnection : DbContext
	{
		protected abstract string ReturnConnectionString();

		protected string ConnectionString { get; private set; }

		public DbSet<User> Users => Set<User>();
		public DbSet<NetworkData> NetworkDatas => Set<NetworkData>();

		public DbSet<Message> Messages => Set<Message>();

		public ADatabaseConnection()
		{
			this.ConnectionString = this.ReturnConnectionString();
			this.Database.EnsureCreated();
		}
	}
}
