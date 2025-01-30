using Microsoft.EntityFrameworkCore;
using TopChat.Models;

namespace TopChat.Services.Interfaces
{
	public abstract class ADatabaseConnection : DbContext
	{
		protected abstract string ReturnConnectionString();

		protected string ConnectionString { get; private set; }

		public DbSet<User> Users => Set<User>();

		public DbSet<NetworkData> NetworkData => Set<NetworkData>();

        public DbSet<MediaData> MediaData => Set<MediaData>();

        public DbSet<Message> Messages => Set<Message>();

		public ADatabaseConnection()
		{
			this.ConnectionString = this.ReturnConnectionString();
			this.Database.EnsureCreated();
		}
	}
}
