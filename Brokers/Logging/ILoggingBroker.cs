//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

namespace Bank_management.Brokers.Logging
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
    }
}
