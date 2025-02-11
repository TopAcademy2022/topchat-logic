namespace TopChat.Services.Interfaces
{
    public interface IUserServes
    {
		public bool Registration(string login, string password);

		public bool FindUser( string login);

	}
}
