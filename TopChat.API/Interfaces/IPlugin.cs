using System.Collections.Generic;
using TopChat.API.Entities;

namespace TopChat.API.Interfaces
{
    public interface IPlugin
    {
        public string GetName();

        public string GetVersion();

        public List<PluginRealization> GetRealizations();

        public void Invoke();
    }
}
