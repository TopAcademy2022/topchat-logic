using TopChat.API.Interfaces;
using TopChat.Domain.Interfaces;

namespace TopChat.UI
{
    public class UtilityUserInterface : IUserInterface
    {
		private readonly IKernelService _kernelService;

		public UtilityUserInterface(IKernelService kernelService)
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

        public void SelectPluginFromList()
		{
			this.PrintPluginList();

            List<IPlugin> plugins = this._kernelService.GetPlugins();

			if (plugins.Count > 0)
			{
                int selectItem = Convert.ToInt32(Console.ReadLine());

                if (selectItem > 0 && selectItem <= plugins.Count)
                {
					this._kernelService.RegisterPluginRealizations(plugins[selectItem - 1].GetName());
                }
            }
		}

    }
}
