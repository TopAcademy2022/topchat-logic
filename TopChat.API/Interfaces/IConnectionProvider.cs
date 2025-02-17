namespace TopChat.API.Interfaces
{
    public interface IConnectionProvider
    {
        public bool Send(byte[] data);

        public byte[] Receive();
    }
}
