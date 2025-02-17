using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TopChat.API.Entities;
using TopChat.API.Interfaces;
using TopChat.Domain.Interfaces;

namespace TopChat.Application.Services
{
    public class KernelService : IKernelService
    {
        private readonly List<IPlugin> _plugins;

        private readonly Dictionary<string, PluginRealization> _realizations;

        private readonly ILogger _logger;

        private readonly IConfiguration _configuration;

		private readonly IDependencyInjection _dependencyInjection;

		public KernelService(ILogger logger,
            IConfiguration configuration,
            IDependencyInjection dependencyInjection)
        {
            this._plugins = new List<IPlugin>();
            this._realizations = new Dictionary<string, PluginRealization>();
            this._logger = logger;
            this._configuration = configuration;
            this._dependencyInjection = dependencyInjection;
        }

		public void Init()
        {
			string pathToPlugins = this._configuration.GetPluginsDirectory();

            if (!Directory.Exists(pathToPlugins))
            {
				Directory.CreateDirectory(pathToPlugins);
			}
		}


		public void LoadPlugin(string pathToPlugin)
        {
            Assembly? loadedPlugin = Assembly.LoadFrom(pathToPlugin);

            if (loadedPlugin != null)
            {
                foreach (Type? classFromPlugin in loadedPlugin.GetTypes())
                {
                    if (classFromPlugin != null)
                    {
                        // && typeof(IPlugin).IsAssignableFrom(classFromPlugin)
                        if (!classFromPlugin.IsInterface)
                        {
                            IPlugin? plugin = Activator.CreateInstance(classFromPlugin) as IPlugin;
                            if (plugin != null)
                            {
                                this._plugins.Add(plugin);

                                // Register realizations
                                string pluginName = plugin.GetName();
                                foreach (PluginRealization realization in plugin.GetRealizations())
                                {
                                    this._realizations.Add(pluginName, realization);
                                }
                                this._logger.Log($"Plugin {plugin.GetName()} loaded.");
                            }
                        }
                    }
                }
            }
        }

        public void LoadDefaultPlugins()
        {
            string pathToPlugins = this._configuration.GetPluginsDirectory();

            try
            {
                string[] files = Directory.GetFiles(pathToPlugins);
                foreach (string file in files)
                {
                    this.LoadPlugin(file);
                }
            }
            catch (Exception ex)
            {
                this._logger.Log($"Not found default directory. Error: {ex.Message}");
            }
        }

        public void InvokePlugins()
        {
            foreach (IPlugin plugin in this._plugins)
            {
                plugin.Invoke();
            }
        }

        public List<IPlugin> GetPlugins()
        {
            return this._plugins;
        }
    }
}
