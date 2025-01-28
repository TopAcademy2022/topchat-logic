using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
    public class MessageServiceClient : IMessageService
    {
        private IDataConverterService _iDataConverterService;

        private INetworkDataService _iNetworkDataService;

        public MessageServiceClient(IDataConverterService iDataConverterService,
            INetworkDataService iNetworkDataService)
        {
            this._iDataConverterService = iDataConverterService;
            this._iNetworkDataService = iNetworkDataService;
        }

        public bool AddMessage(Message message)
        {
            NetworkData networkData = this._iDataConverterService.ConvertToNetworkData(message);
            return this._iNetworkDataService.Send(networkData);
        }

        //public List<Message> GetMessages(User sender)
        //{
        //    NetworkData networkData = this._iNetworkDataService.Get(this._iNetworkDataService.CreateRequest(sender, true));
        //    return this._iDataConverterService.ConvertFromNetworkData<List<Message>>(networkData);
        //}
    }
}
