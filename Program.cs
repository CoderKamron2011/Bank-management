using Bank_management.Model;
using Bank_management.Services.Registrs;
using System;

namespace Bank_management
{
    class Program
    {
        static void Main(string[] args)
        {
            IRegisterService registerService = new RegisterService();

            Console.WriteLine("Welcome to Bank Management System!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your name: ");
                        string loginName = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string loginPassword = Console.ReadLine();

                        User loginUser = new User
                        {
                            Name = loginName,
                            Password = loginPassword
                        };

                        bool loginResult = registerService.LogIn(loginUser);
                        if (loginResult)
                        {
                            Console.WriteLine("Login successful!");
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Please try again.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter your name: ");
                        string signupName = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string signupPassword = Console.ReadLine();

                        User signupUser = new User
                        {
                            Name = signupName,
                            Password = signupPassword
                        };

                        User signupResult = registerService.SignUp(signupUser);
                        if (signupResult != null)
                        {
                            Console.WriteLine("Sign up successful!");
                        }
                        else
                        {
                            Console.WriteLine("Sign up failed. Please try again.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Exiting Bank Management System. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }


}

