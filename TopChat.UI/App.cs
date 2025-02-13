using TopChat.API.Interfaces;
using TopChat.Domain.Interfaces;

namespace TopChat.UI
{
    public class App
    {
        private readonly IKernelService _kernelService;

        private readonly IUserInterface _userInterface;

		public App(IKernelService kernelService, IUserInterface userInterface)
        {
            this._kernelService = kernelService;
            this._userInterface = userInterface;
        }

        private void CommandHandler(string? command)
        {
            switch (command)
            {
				case "--init":
                    this._kernelService.Init();
					break;
				case "--list":
                    this._userInterface.PrintPluginList();
                    break;
				case "--help":
					// Print command list
					break;
				default:
					this._kernelService.Init();
					this._kernelService.LoadDefaultPlugins();
					this._kernelService.InvokePlugins();
					break;
            }
        }

        public void Run()
        {
			string[] commandLineArgs = Environment.GetCommandLineArgs();

			if (commandLineArgs.Length > 0)
            {
                foreach (string command in commandLineArgs)
                {
					this.CommandHandler(command);
				}
            }
        }
    }
}
