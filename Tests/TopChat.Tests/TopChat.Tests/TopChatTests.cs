using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using TopChat.Services;
using TopChat.Services.Interfaces;

namespace TopChat.Tests
{
	public class TopChatTests
	{
		[Fact]
		public void SqliteConnectionTest()
		{
			SqliteConnection connection = new SqliteConnection();

			Assert.True(connection.Database.CanConnect());
		}
	}
}