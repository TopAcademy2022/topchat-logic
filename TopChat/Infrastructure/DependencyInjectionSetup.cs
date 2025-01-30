using Microsoft.Extensions.DependencyInjection;
using TopChat.Services;
using TopChat.Services.Interfaces;

namespace TopChat.Infrastructure
{
    public class DependencyInjectionSetup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IDataConverterService, DataConverterService>();
            services.AddScoped<ADatabaseConnection, SqliteConnection>();
            services.AddScoped<IConnectionProvider, ConnectionProviderUdp>();
            services.AddScoped<IMessageService, MessageServiceClient>();
            services.AddScoped<INetworkDataService, NetworkDataService>();
        }
    }
}
