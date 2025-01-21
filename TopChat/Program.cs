using System.Net;
using System.Net.Sockets;
using TopChat;

const ushort APP_PORT = 5000;

Console.WriteLine("Введите IP ПК, которому будете отправлять запросы:");
string destinationIP = Console.ReadLine();

Console.WriteLine("Введите ваш логин:");
string userLogin = Console.ReadLine();

// Задать адрес, куда будет отправлять наши сообщения
IPAddress iPAddress = IPAddress.Parse(destinationIP);
// Задать точку назначения (на какой IP отправлять данные)
IPEndPoint destinationEndPoint = new IPEndPoint(iPAddress.Address, APP_PORT);

// Создать объект класса Socket для работы по сети
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
// Задать точку назначения (наш IP для прослушивания сообщений)
IPEndPoint myIP = new IPEndPoint(IPAddress.Any, APP_PORT);
// Привязаться к точке назначения (работать с ней)
socket.Bind(myIP);

while (true)
{
	Message message = new Message(socket, userLogin, destinationEndPoint);
	message.StartListen();
	message.Write();
}

// Завершить работу по сети
socket.Close();
