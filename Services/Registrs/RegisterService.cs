//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Brokers.Logging;
using Bank_management.Brokers.Storage;
using Bank_management.Brokers.Storage.Register;
using Bank_management.Model;

namespace Bank_management.Services.Registrs
{
    internal class RegisterService : IRegisterService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IRegisterBroker registerBroker;
        public RegisterService()
        {
            this.loggingBroker = new LoggingBroker();
            this.registerBroker = new RegisterBroker();
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
            this.loggingBroker.LogError("User information is null or empty.");
            return new User();
        }
        private User ValidationAndSignUpUser(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Name)
                || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogError("User information is incomplete");
                return new User();
            }
            else
            {
                User userInformation = this.registerBroker.AddUser(user);

                if (user.Password.Length >= 8)
                {
                    if (userInformation is null)
                    {
                        this.loggingBroker.LogError("This user base is available.");
                        return new User();
                    }
                    else
                    {
                        this.loggingBroker.LogInformation("User added successfully.");
                        return user;
                    }
                }
                else
                {
                    this.loggingBroker.LogError("Password does not contain 8 characters.");
                    return new User();
                }
            }
        }
        private bool InvalidLogInUser()
        {
            this.loggingBroker.LogError("User data is null.");
            return false;
        }
        private bool ValidationAndLogIn(User user)
        {
            if (String.IsNullOrWhiteSpace(user.Name)
                || String.IsNullOrWhiteSpace(user.Password))
            {
                this.loggingBroker.LogInformation("User data is not required.");
                return false;
            }
            else
            {
                bool isLogIn = this.registerBroker.GetUser(user);

                if (user.Password.Length >= 8)
                {
                    if (isLogIn is true)
                    {
                        this.loggingBroker.LogInformation("Successfully logged in.");
                        return true;
                    }
                    else
                    {
                        this.loggingBroker.LogError("User does not exist in the database.");
                        return false;
                    }
                }
                else
                {
                    this.loggingBroker.LogError("Password does not contain 8 characters.");
                    return false;
                }
            }
        }
    }
}
