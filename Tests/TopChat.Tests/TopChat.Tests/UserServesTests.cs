using TopChat.Services;
using TopChat.Services.Interfaces;

namespace TopChat.Tests
{
    public class UserServesTests
    {
        [Fact]
        public void RegistrationTest()
        {
            ADatabaseConnection databaseConnection = new SqliteConnection();
            UserServes userServes = new UserServes(databaseConnection);
            string testLogin = "testUser";
            string testPassword = "testPassword";

            userServes.Registration(testPassword, testLogin);

            //Assert.Single(databaseConnection.Users);
            Assert.Equal(testLogin, databaseConnection.Users.First().Login); 
            Assert.Equal(testPassword, databaseConnection.Users.First().Password);
        }
    }
}