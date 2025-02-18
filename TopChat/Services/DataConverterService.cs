using SharpCompress.Common;
using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using TopChat.Models;
using TopChat.Services.Interfaces;
using System.Collections.Generic;

namespace TopChat.Services
{
	public class DataConverterService : IDataConverterService
	{
		public NetworkData ConvertToNetworkData(Message fromEntity) 
		{
			NetworkData result = new NetworkData();

				result.DestinationIP = "127.0.0.1"; //message.Sender.GetIpFromService()
				result.DestinationPort = 5000;

			if (fromEntity.MediaData.Text != "" && fromEntity.MediaData.PathToFile == null)
			{
				result.Data = new byte[1024];
				string dataText = $"{fromEntity.DateTime}|{fromEntity.MediaData.Text}";
				result.Data = Encoding.UTF8.GetBytes(dataText);

				return result;
			}
			else
			{
				result.Data = File.ReadAllBytes(fromEntity.MediaData.PathToFile);

				byte[] fileNameBytes = System.Text.Encoding.UTF8.GetBytes(Path.GetFileName(fromEntity.MediaData.PathToFile));
			}
			return result;
		}

		public List<Message> ConvertFromNetworkData(NetworkData result)
		{

			List < Message > messages = new List < Message >();

			byte[] received = new byte[1024];

			if (Convert.ToInt32(result.Data) < 1024)
			{
				byte[] receivedBytes = result.Data;
				string receivedText = Encoding.UTF8.GetString(receivedBytes);

				string[] splitText = receivedText.Split('|');

				if (splitText[0] == "get")
				{
					messages.Add(new Message() { });
				}

			}
			else
			{

			}
			return messages;
		}
	}
}
