//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Services.BankProcessingService
{
    internal interface IBankProcessingService
    {
        bool DeleteForClient(decimal accountNumber);
        decimal GetBalance(decimal accountNumberForBank);
        decimal GetMoney(decimal accountNumberForBank, decimal balance);
        bool LogInUser(User user);
        bool PostDeposit(decimal accountNumberForBank, decimal balance);
        bool PostForClient(Customer customer);
        User PostUser(User user);
        bool TransferMoneyBetweenAccountsForClient(
                decimal firstAccountNumber,
                decimal secondAccountNumber,
                decimal money);
    }
}
