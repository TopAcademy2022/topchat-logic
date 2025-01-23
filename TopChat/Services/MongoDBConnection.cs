using Microsoft.EntityFrameworkCore;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
    public class MongoDBConnection : ADatabaseConnection
    {
        public const string _DATABASE_NAME = "../TopChat.db";

        protected override string ReturnConnectionString()
        {
            return $"Data Source={_DATABASE_NAME}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMongoDB(this.ConnectionString, "TopChat");
        }
    }
}
