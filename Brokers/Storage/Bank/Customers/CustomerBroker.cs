//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Brokers.Storage.Bank.Customers;

namespace Bank_management.Brokers.Storage.Bank.Customer
{
    internal class CustomerBroker : ICustomerBroker
    {
        private readonly string filePath = "../../../Assets/CustomerFileDB.txt";
        private bool isDelete;
        public CustomerBroker()
        {
            isDelete = false;
            EnsureFileExists();
        }

        public bool CloseAccountNumberForClient(decimal accountNumber)
        {
            string[] clientAllInfo = File.ReadAllLines(filePath);
            File.WriteAllText(filePath, string.Empty);

            for (int itaration = 0; itaration < clientAllInfo.Length; itaration++)
            {
                string clientInfo = clientAllInfo[itaration];
                string[] client = clientInfo.Split('*');

                if (client[1].Contains(accountNumber.ToString()) is true)
                {
                    isDelete = true;
                }
                else
                {
                    File.AppendAllText(filePath, clientInfo + "\n");
                }
            }

            return isDelete;
        }

        public bool CreateAccountNumberForClient(Model.Customer customer)
        {
            string[] clientAllInfo = File.ReadAllLines(filePath);

            for (int itaration = 0; itaration < clientAllInfo.Length; itaration++)
            {
                string clientInfo = clientAllInfo[itaration];
                string[] client = clientInfo.Split('*');

                if (client[0].Contains(customer.Name)
                    && client[1].Contains(customer.AccountNumber.ToString()))
                {
                    return false;
                }
            }

            string newClient = $"{customer.Name}*{customer.AccountNumber}*{customer.Balance}\n";
            File.AppendAllText(filePath, newClient);
            return true;
        }

        public bool TransferMoneyBetweenAccounts(decimal firstAccountNumber, decimal secondAccountNumber, decimal money)
        {
            string[] clientInfo = File.ReadAllLines(filePath);
            File.WriteAllText(filePath, string.Empty);

            if (IsAccountNumberCheck(firstAccountNumber)
                && IsAccountNumberCheck(secondAccountNumber))
            {
                int firstIndex = this.GetIndex(firstAccountNumber);
                int secondIndex = this.GetIndex(secondAccountNumber);

                string[] firstClientInfoLine = clientInfo[firstIndex].Split('*');
                string[] secondClinetInfoLine = clientInfo[secondIndex].Split('*');

                if (Convert.ToDecimal(firstClientInfoLine[2]) >= money)
                {
                    File.WriteAllText(filePath, string.Empty);
                    decimal firstAccount = Convert.ToDecimal(firstClientInfoLine[2]);
                    firstAccount -= money;
                    firstClientInfoLine[2] = firstAccount.ToString();

                    decimal secondAccount = Convert.ToDecimal(secondClinetInfoLine[2]);
                    secondAccount += money;
                    secondClinetInfoLine[2] = secondAccount.ToString();

                    for (int itarator = 0; itarator < clientInfo.Length; itarator++)
                    {
                        if (itarator == firstIndex)
                        {
                            clientInfo[itarator] = $"{firstClientInfoLine[0]}*{firstClientInfoLine[1]}*{firstClientInfoLine[2]}";
                        }
                        else if (itarator == secondIndex)
                        {
                            clientInfo[itarator] = $"{secondClinetInfoLine[0]}*{secondClinetInfoLine[1]}*{secondClinetInfoLine[2]}";
                        }
                    }

                    return true;
                }

            }

            return false;
        }

        private bool IsAccountNumberCheck(decimal accountNumber)
        {
            string[] clientAllInfo = File.ReadAllLines(filePath);

            for (int itaration = 0; itaration < clientAllInfo.Length; itaration++)
            {
                string clietInfo = clientAllInfo[itaration];
                string[] client = clietInfo.Split('*');
                if (client[1].Contains(accountNumber.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        private int GetIndex(decimal accountNumber)
        {
            string[] clientAllInfo = File.ReadAllLines(filePath);

            for (int itaration = 0; itaration < clientAllInfo.Length; itaration++)
            {
                string clietInfo = clientAllInfo[itaration];
                string[] client = clietInfo.Split('*');
                if (client[1].Contains(accountNumber.ToString()))
                {
                    return itaration;
                }
            }

            return -1;
        }

        private void EnsureFileExists()
        {
            bool isFileThere = File.Exists(filePath);

            if (isFileThere is false)
            {
                File.Create(filePath).Close();
            }
        }

        public string ReadAllCustomers()
        {
            string clientInfo = File.ReadAllText(filePath);
            return clientInfo;
        }

        public decimal GetBalance(decimal accountNumber)
        {
            if (accountNumber.ToString().Length >= 16)
            {
                string[] accountLines = File.ReadAllLines(filePath);

                for (int itarator = 0; itarator < accountLines.Length; itarator++)
                {
                    string accountLine = accountLines[itarator];
                    string[] clientInfo = accountLine.Split('*');

                    if (clientInfo[1].Contains(accountNumber.ToString()))
                    {
                        return Convert.ToDecimal(clientInfo[2]);
                    }
                }

                return 0;
            }

            return 0;
        }
    }
}
