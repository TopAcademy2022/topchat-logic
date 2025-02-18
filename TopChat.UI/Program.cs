using Microsoft.Extensions.DependencyInjection;
using TopChat.API.Interfaces;
using TopChat.Domain.Interfaces;
using TopChat.Application.Services;
using TopChat.Infrastruction.Services;
using TopChat.UI;

try
{
    // Select default Dependency Injection
    ServiceCollection? services = new ServiceCollection();
    if (services != null)
    {
        services.AddScoped<IKernelService, KernelService>();
        services.AddScoped<ILogger, ConsoleLoggerService>();
        services.AddScoped<IConfiguration, JsonConfiguration>();
		services.AddScoped<IDependencyInjection, DefaultDependencyInjection>();
		//services.AddScoped<AppDbContext, SqliteConnection>();
		services.AddScoped<IUserInterface, UtilityUserInterface>();
	}
    else
    {
        throw new Exception("DI error.");
    }

    // Create DI provider
    ServiceProvider? serviceProvider = services.BuildServiceProvider();

    // Use services
    if (serviceProvider != null)
    {
        IKernelService? kernelService = serviceProvider.GetService<IKernelService>();
		IUserInterface? userInterface = serviceProvider.GetService<IUserInterface>();

		if (kernelService != null && userInterface != null)
        {
            App app = new App(kernelService, userInterface);
            app.Run();
        }
        else
        {
            throw new Exception("Error: Kernel or UI class not find.");
        }
    }
    else
    {
        throw new Exception("Error: No get services.");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
