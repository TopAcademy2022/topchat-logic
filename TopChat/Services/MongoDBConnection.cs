using Microsoft.EntityFrameworkCore;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class MongoDBConnection : ADatabaseConnection
	{
		public const string _DATABASE_NAME = "/admin";

		protected override string ReturnConnectionString()
		{
			return $"mongodb://localhost:27017/";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMongoDB(this.ConnectionString, _DATABASE_NAME);
		}
		public bool CheckConnection(string connectionString)
		{
			try
			{
				using (var dbContext = new MyDbContext(connectionString))
				{
					return dbContext.Database.CanConnect();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при проверке подключения: {ex.Message}");
				return false;
			}
		}
	}
}