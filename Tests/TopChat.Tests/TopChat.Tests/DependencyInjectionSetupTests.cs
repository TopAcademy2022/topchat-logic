using Microsoft.Extensions.DependencyInjection;
using TopChat.Services.Interfaces;


namespace TopChat.Tests
{
	public class DependencyInjectionSetupTests
	{
		private ADatabaseConnection? _connection;

		private IMessageService? _messageService;

		private IConnectionProvider? _connectionProvider;

		private IGroupService? _grouping;

		private INetworkDataService? _networkDataService;

		private IUserServes? _userServes;

		[Fact]
		public void DependencyInjectionTest()
		{
			ServiceCollection services = new ServiceCollection();

			TopChat.Infrastructure.DependencyInjectionSetup.ConfigureServices(services);

			using var serviceProvider = services.BuildServiceProvider();

			this._connection = serviceProvider.GetService<ADatabaseConnection>();

			this._messageService = serviceProvider.GetService<IMessageService>();

			this._connectionProvider = serviceProvider.GetService<IConnectionProvider>();

			this._grouping = serviceProvider.GetService<IGroupService>();

			this._networkDataService = serviceProvider.GetService<INetworkDataService>();

			this._userServes = serviceProvider.GetService<IUserServes>();

			Assert.True(this._messageService.GetType().Name == "MessageServiceClient");
			Assert.True(this._connection.GetType().Name == "SqliteConnection");
			Assert.True(this._connectionProvider.GetType().Name == "ConnectionProviderUdp");
			Assert.True(this._networkDataService.GetType().Name == "NetworkDataService");
			Assert.True(this._userServes.GetType().Name == "UserServes");
			Assert.True(this._grouping.GetType().Name == "GroupService");
		}
	}
}
