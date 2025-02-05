namespace TopChat.Services.Interfaces
{
    public interface IServerLogic
    {
		public void StartListen();

		public List<byte> GetListBytes();

	}
}
