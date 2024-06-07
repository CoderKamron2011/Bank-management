//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Brokers.Logging;
using Bank_management.Brokers.Storage;
using Bank_management.Model;

namespace Bank_management.Services.Registrs
{
    internal class RegisterService : IRegisterService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IRegisterBroker storageBroker;
        public RegisterService()
        {
            this.loggingBroker = new LoggingBroker();
            this.storageBroker = new RegisterBroker();
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
            this.loggingBroker.LogError("User information is null.");
            return new User();
        }
        private User ValidationAndSignUpUser(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Name)
              || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogError("Invalid user information");
                return new User();
            }
            else
            {
                var userInformation = this.storageBroker.AddUser(user);
                if (userInformation is null)
                {
                    this.loggingBroker.LogError("Not added user information");
                }
                else
                {
                    this.loggingBroker.LogInformation("Added user");
                }
                return userInformation;
            }
        }
        private bool InvalidLogInUser()
        {
            this.loggingBroker.LogError("your name or password is null");
            return false;
        }
        private bool ValidationAndLogIn(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Name)
                || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogError("Incoming data is incomplete");
                return false;
            }
            else
            {
                bool userInfo = this.storageBroker.GetUser(user);
                if (userInfo is true)
                {
                    this.loggingBroker.LogInformation("successfull");
                }
                else
                {
                    this.loggingBroker.LogError("Not found");
                }
                return userInfo;
            }
        }
    }
}
