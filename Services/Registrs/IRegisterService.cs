using Bank_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management.Services.Registrs
{
    internal interface IRegisterService
    {
        bool LogIn(User user);
        User SignUp(User user);
    }
}
