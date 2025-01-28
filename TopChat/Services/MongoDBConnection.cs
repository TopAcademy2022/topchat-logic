//using Microsoft.EntityFrameworkCore;
//using TopChat.Services.Interfaces;

//namespace TopChat.Services
//{
//	public class MongoDBConnection : ADatabaseConnection
//	{
//		public const string _DATABASE_NAME = "/mongosh+2.3.8";

//		protected override string ReturnConnectionString()
//		{
//			return $"mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName={_DATABASE_NAME}";
//		}

//		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//		{
//			optionsBuilder.UseMongoDB(this.ConnectionString, _DATABASE_NAME);
//			Console.WriteLine("Успешное подключение");
//		}
//	}
//}