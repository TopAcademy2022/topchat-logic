using TopChat.Services;
using TopChat.Services.Interfaces;

namespace TopChat.Tests
{
    public class UserServesTests
    {
        private ADatabaseConnection _db;
        public UserServesTests()
        {
            this._db = new SqliteConnection();
        }
        [Fact]
        public void RegistrationTest()
        {
            UserServes userServes = new UserServes(_db);
            string testLogin = "testUser";
            string testPassword = "testPassword";

            userServes.Registration(testPassword, testLogin);

            Assert.Single(_db.Users);
            Assert.Equal(testLogin, _db.Users.First().Login); 
            Assert.Equal(testPassword, _db.Users.First().Password);

            _db.Database.EnsureDeleted();
        }
    }
}