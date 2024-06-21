//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management;

namespace Bank_management.Brokers.Storage.Bank.Customers
{
    internal interface ICustomerBroker
    {
        bool CreateAccountNumberForClient(Model.Customer customer);
        bool CloseAccountNumberForClient(decimal accountNumber);
        bool TransferMoneyBetweenAccounts(
            decimal firstAccountNumber
            , decimal secondAccountNumber
            , decimal money);
    }
}