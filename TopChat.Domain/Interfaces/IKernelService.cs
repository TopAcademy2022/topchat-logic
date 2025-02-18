using System;
using System.Collections.Generic;
using TopChat.API.Interfaces;

namespace TopChat.Domain.Interfaces
{
    public interface IKernelService
    {
        public void Init();

        public void LoadPlugin(string pathToPlugin);

        public void LoadDefaultPlugins();

        public void InvokePlugins();

        public List<IPlugin> GetPlugins();

        public void RegisterPluginRealizations(string pluginName);

        public Type? GetClassFromAssembly(string className);
	}
}
