//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Services.Registrs
{
    internal interface IRegisterService
    {
        bool LogIn(User user);
        User SignUp(User user);
    }
}
