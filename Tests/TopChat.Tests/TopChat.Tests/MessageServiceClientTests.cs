using TopChat.Models;
using TopChat.Services;
using TopChat.Services.Interfaces;

namespace TopChat.Tests
{
    public class MessageServiceClientTests
    {
        private IDataConverterService _iDataConverterService;

        private INetworkDataService _iNetworkDataService;

        public MessageServiceClientTests()
        {
            IConnectionProvider connectionProvider = new ConnectionProviderUdp();

            this._iDataConverterService = new DataConverterService();
            this._iNetworkDataService = new NetworkDataService(connectionProvider);
        }

        [Fact]
        public void AddMessageTest()
        {
            MessageServiceClient messageServiceClient = new MessageServiceClient(
                this._iDataConverterService,
                this._iNetworkDataService);

            Message someMessage = new Message()
            {
                MediaData = new Media()
                {
                    Text = "Test",
                    PathToFile = String.Empty
                },
                Sender = new User(),
                Recipient = new User(),
                DateTime = DateTime.Now
            };

            Assert.True(messageServiceClient.AddMessage(someMessage));
        }
    }
}