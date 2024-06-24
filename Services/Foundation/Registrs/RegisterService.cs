//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Brokers.Logging;
using Bank_management.Brokers.Storage;
using Bank_management.Brokers.Storage.Register;
using Bank_management.Model;

namespace Bank_management.Services.Foundation.Registrs
{
    internal class RegisterService : IRegisterService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IRegisterBroker registerBroker;
        public RegisterService()
        {
            loggingBroker = new LoggingBroker();
            registerBroker = new RegisterBroker();
        }
        public bool LogIn(User user)
        {
            return user is null
                ? InvalidLogInUser()
                : ValidationAndLogIn(user);
        }
        public User SignUp(User user)
        {
            return user is null
                ? InvalidSignUp()
                : ValidationAndSignUpUser(user);
        }
        private User InvalidSignUp()
        {
            loggingBroker.LogError("User information is null or empty.");
            return new User();
        }
        private User ValidationAndSignUpUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name)
                || string.IsNullOrWhiteSpace(user.Password))
            {
                loggingBroker.LogError("User information is incomplete");
                return new User();
            }
            else
            {
                User userInformation = registerBroker.AddUser(user);

                if (user.Password.Length >= 8)
                {
                    if (userInformation.Name is null)
                    {
                        this.loggingBroker.LogError("This user is available in the database.");
                        return new User();
                    }
                    else
                    {
                        loggingBroker.LogInformation("User added successfully.");
                        return user;
                    }
                }
                else
                {
                    loggingBroker.LogError("Password does not contain 8 characters.");
                    return new User();
                }
            }
        }
        private bool InvalidLogInUser()
        {
            loggingBroker.LogError("User data is null.");
            return false;
        }
        private bool ValidationAndLogIn(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name)
                || string.IsNullOrWhiteSpace(user.Password))
            {
                loggingBroker.LogInformation("User data is not required.");
                return false;
            }
            else
            {
                bool isLogIn = registerBroker.GetUser(user);

                if (user.Password.Length >= 8)
                {
                    if (isLogIn is true)
                    {
                        loggingBroker.LogInformation("Successfully logged in.");
                        return true;
                    }
                    else
                    {
                        loggingBroker.LogError("User does not exist in the database.");
                        return false;
                    }
                }
                else
                {
                    loggingBroker.LogError("Password does not contain 8 characters.");
                    return false;
                }
            }
        }
    }
}
