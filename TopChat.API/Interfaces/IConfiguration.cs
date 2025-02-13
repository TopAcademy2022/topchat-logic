namespace TopChat.API.Interfaces
{
    public interface IConfiguration
    {
        public string GetPluginsDirectory();

        public void SetPluginsDirectory();
    }
}
