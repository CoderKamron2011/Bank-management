﻿//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Model;

namespace Bank_management.Services.BankProcessingService
{
    internal interface IBankProcessingService
    {
        internal interface IBankProcessingsService
        {
            public bool DeleteForClient(decimal accountNumber);
            public decimal GetBalance(decimal accountNumberForBank);
            public decimal GetMoney(decimal accountNumberForBank, decimal balance);
            public bool LogInUser(User user);
            public bool PostDeposit(decimal accountNumberForBank, decimal balance);
            public bool PostForClient(Customer customer);
            public User PostUser(User user);
            public bool TransferMoneyBetweenAccountsForClient(
                    decimal firstAccountNumber,
                    decimal secondAccountNumber,
                    decimal money);
        }
    }
}
