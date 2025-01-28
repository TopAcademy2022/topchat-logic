using TopChat.Services;

namespace TopChat.Tests
{
    public class TopChatTests
    {
        [Fact]
        public void Test_SetDestinationUdp()
        {
            ConnectionProviderUdp connectionProviderUdp = new ConnectionProviderUdp();

            Assert.True(connectionProviderUdp.SetDestination("127.0.0.1", 12345));
        }

        [Fact]
        public void Test_SendUdp()
        {
            ConnectionProviderUdp connectionProviderUdp = new ConnectionProviderUdp();
            Assert.True(connectionProviderUdp.SetDestination("127.0.0.1", 12345));

            byte[] buffer_test = new byte[1024];

            Assert.True(connectionProviderUdp.Send(buffer_test));
        }
    }
}
