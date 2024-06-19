//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Services.Foundation.Banks.Customers
{
    internal interface ICustomerService
    {
        bool CreateClient(Customer customer);
        bool DeleteClient(decimal accountNumber);

        bool TransferMoneyBetweenClients(
            decimal firstAccountNumber,
            decimal secondAccountNumber,
            decimal money);
    }
}
