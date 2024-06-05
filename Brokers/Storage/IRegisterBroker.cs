using Bank_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management.Brokers.Storage
{
    internal interface IRegisterBroker
    {
        User AddUser(User user);
        bool LogIn(User user);
    }
}
