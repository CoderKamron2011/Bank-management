﻿//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Brokers.Storage.Register
{
    internal class RegisterBroker : IRegisterBroker
    {
        private readonly string filePath = "../../../Assets/RegistrFileDb.txt";

        public RegisterBroker()
        {
            EnsureFileExists();
        }

        public User AddUser(User user)
        {
            string[] userLines = File.ReadAllLines(filePath);

            for (int itaration = 0; itaration > userLines.Length; itaration++)
            {
                string userLine = userLines[itaration];
                string[] userInfo = userLine.Split('*');

                if (userInfo[0].Contains(user.Name)
                    && userInfo[1].Contains(user.Password))
                {
                    return new User();
                }
            }

            string userNewLine = $"{user.Name}*{user.Password}\n";
            File.AppendAllText(filePath, userNewLine);
            return user;
        }

        public bool GetUser(User user)
        {
            string[] userLines = File.ReadAllLines(filePath);

            for (int itaration = 0; itaration < userLines.Length; itaration++)
            {
                string userLine = userLines[itaration];
                string[] userInfo = userLine.Split('*');

                if (userInfo[0].Contains(user.Name)
                    && userInfo[1].Contains(user.Password))
                {
                    return true;
                }
            }

            return false;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(filePath);

            if (fileExists is false)
            {
                File.Create(filePath).Close();
            }
        }
    }
}
