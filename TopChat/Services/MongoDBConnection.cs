using Microsoft.EntityFrameworkCore;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class MongoDBConnection : ADatabaseConnection
	{
		public const string _DATABASE_NAME = "local";

		protected override string ReturnConnectionString()
		{
			return $"mongodb://localhost:27017";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMongoDB(this.ConnectionString, _DATABASE_NAME);
		}
	}
}