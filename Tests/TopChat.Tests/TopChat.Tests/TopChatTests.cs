using Microsoft.EntityFrameworkCore;
using TopChat.Services;

namespace TopChat.Tests
{
    public class TopChatTests
    {
        [Fact]
        public void MongoDBConnectionTest()
        {
            MongoDBConnection connection = new MongoDBConnection();

		
				try
				{
				
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Ошибка при проверке подключения: {ex.Message}");
					return false;
				}
			
    }
}