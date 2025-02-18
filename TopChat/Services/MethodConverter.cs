
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class MethodConverter
	{
		private UserServes _userServes;

		private ADatabaseConnection _connectionDB;

		private ConnectionProviderUdp _connectionProviderUdp;

		public MethodConverter(UserServes userServes, ConnectionProviderUdp connectionProviderUdp)
		{
			this._userServes = userServes;
			this._connectionProviderUdp = connectionProviderUdp;
		}

		public bool DatabaseConnection()
		{
			this._connectionDB = new SqliteConnection();

			if (this._connectionDB.Database.CanConnect())
			{
				return true;
			}

			return false;
		}

		public bool RegistrationUser(string username, string password)
		{

			return false;
		}

		public bool SendMessage()
		{
			return true;
		}

		public bool ReceiveMessage()
		{
			return true;
		}
	}
}
