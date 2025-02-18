using System;
using System.Text;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class DataBaseService : IDataBaseService
	{
		private IDataConverterService _converterService;

		private ADatabaseConnection _connection;

		public DataBaseService(IDataConverterService converterService, ADatabaseConnection connection)
		{
			this._converterService = converterService;
			this._connection = connection;
		}
		public void AddMessage(byte[] bytesData)
		{
			Message message = new Message();

			string receivedText = Encoding.UTF8.GetString(bytesData);

			string[] dataSplitText = receivedText.Split('|');

			message.DateTime = Convert.ToDateTime( dataSplitText[0]);

			message.MediaData = new Media() { Text = dataSplitText[1] };

			this._connection.Messages.Add(message);

		}
	}
}
