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

        private readonly Dictionary<string, List<PluginRealization>> _realizations;

        private readonly ILogger _logger;

        private readonly IConfiguration _configuration;

		private readonly IDependencyInjection _dependencyInjection;

		public KernelService(ILogger logger,
            IConfiguration configuration,
            IDependencyInjection dependencyInjection)
        {
            this._plugins = new List<IPlugin>();
            this._realizations = new Dictionary<string, List<PluginRealization>>();
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
            if (!String.IsNullOrEmpty(pathToPlugin) && pathToPlugin.Contains(".dll"))
            {
                Assembly? loadedPlugin = Assembly.LoadFrom(pathToPlugin);

                if (loadedPlugin != null)
                {
                    foreach (Type? classFromPlugin in loadedPlugin.GetTypes())
                    {
                        if (classFromPlugin != null && !classFromPlugin.Name.Contains("Attribute"))
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
                                    List<PluginRealization> realizations = new List<PluginRealization>();
                                    foreach (PluginRealization realization in plugin.GetRealizations())
                                    {
                                        realizations.Add(realization);
                                    }
                                    this._realizations.Add(pluginName, realizations);
                                    this._logger.Log($"Plugin {plugin.GetName()} loaded.");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this._logger.Log($"Warning: loading bad path = {pathToPlugin}");
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

        public void RegisterPluginRealizations(string pluginName)
        {
            if (this._realizations.ContainsKey(pluginName))
            {
                List<PluginRealization> realizations = this._realizations[pluginName];
                foreach (PluginRealization realization in realizations)
                {
                    Type? overrideInterface = this.GetClassFromAssembly(realization.InterfaceName);
                    Type? interfaceRealization = this.GetClassFromAssembly(realization.RealizationClassName);

                    if (overrideInterface != null && interfaceRealization != null)
                    {
                        this._dependencyInjection.AddScope(overrideInterface, interfaceRealization);
                    }
                }
            }
        }

        public Type? GetClassFromAssembly(string className)
        {
            const string API_ASSEMBLY_NAME = "TopChat.API";
            List<string> pluginsName = new List<string>();

            foreach (IPlugin plugin in this._plugins)
            {
                pluginsName.Add(plugin.GetName());
            }

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Assembly> needed = new List<Assembly>();

            foreach (Assembly assembly in assemblies)
            {
                if (assembly.FullName.Contains(API_ASSEMBLY_NAME) ||
                    pluginsName.Exists(item => assembly.FullName.Contains(item)))
                {
                    needed.Add(assembly);
                }
            }

            foreach (Assembly assembly in needed)
            {
                Type? type = assembly.GetType(className);

                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
