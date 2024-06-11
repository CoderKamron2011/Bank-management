//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Brokers.Storage.Register
{
    internal interface IRegisterBroker
    {
        User AddUser(User user);
        bool GetUser(User user);
    }
}
