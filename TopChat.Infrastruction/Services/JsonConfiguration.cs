using TopChat.API.Interfaces;

namespace TopChat.Infrastruction.Services
{
    public class JsonConfiguration : IConfiguration
    {
        public string GetPluginsDirectory()
        {
            return "./plugins";
        }

        public void SetPluginsDirectory()
        {

        }
    }
}
