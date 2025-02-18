namespace TopChat.API.Interfaces
{
    public interface IConnectionProvider
    {
        public void SetPort(int port);

        public bool Send(byte[] data, string destinationIp, int destinationPort);

        public byte[] Receive();
    }
}
