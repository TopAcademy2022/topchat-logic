using System;
using TopChat.API.Interfaces;

namespace TopChat.Infrastruction.Services
{
    public class ConsoleLoggerService : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
