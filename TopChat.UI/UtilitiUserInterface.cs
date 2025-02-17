using TopChat.API.Interfaces;
using TopChat.Domain.Interfaces;

namespace TopChat.UI
{
    public class UtilitiUserInterface : IUserInterface
    {
		private readonly IKernelService _kernelService;

		public UtilitiUserInterface(IKernelService kernelService)
		{
			this._kernelService = kernelService;
		}

		public void PrintMenu() {}

		public void PrintPluginList()
        {
			List<IPlugin> plugins = this._kernelService.GetPlugins();

			for (int i = 0; i < plugins.Count; i++)
			{
				Console.WriteLine($"{i + 1}.{plugins[i].GetName()}");
			}
        }
	}
}
