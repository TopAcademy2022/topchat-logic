using Microsoft.EntityFrameworkCore;
//using MongoDB.Driver;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class MongoDBConnection : ADatabaseConnection
	{
		//private readonly IMongoDatabase _database;

		//public MongoDbContext(string connectionString, string databaseName)
		//{
		//	var client = new MongoClient(connectionString);
		//	_database = client.GetDatabase(databaseName);
		//}

		public const string _DATABASE_NAME = "local";

		protected override string ReturnConnectionString()
		{
			return $"mongodb://localhost:27017";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseMongoDB(this.ConnectionString, _DATABASE_NAME);
		}
	}
}