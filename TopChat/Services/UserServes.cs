using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
    public class UserServes : IUserServes
    {
        private ADatabaseConnection _db;
        public UserServes(ADatabaseConnection db)
        {
            this._db = db;
        }

        public void Registration(string password, string login)
        {
            if (_db.Users.Any(u => u.Login == login))
            {
                Console.WriteLine("Такой логин уже существует. Пожалуйста, придумайте новый.");
            }

            User user = new User()
            {
                Login = login,
                Password = password,
            };

            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}
