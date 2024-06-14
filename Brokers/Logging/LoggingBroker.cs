using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management.Brokers.Logging
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInformation(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }
        public void LogError(string userMessage)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(userMessage);
            System.Console.ResetColor();
        }
        public void LogError(Exception exception)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(exception.Message);
            System.Console.ResetColor();
        }
    }
}
}
