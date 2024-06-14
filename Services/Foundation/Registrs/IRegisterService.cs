//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------


//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Services.Foundation.Registrs
{
    internal interface IRegisterService
    {
        bool LogIn(User user);
        User SignUp(User user);
    }
}
