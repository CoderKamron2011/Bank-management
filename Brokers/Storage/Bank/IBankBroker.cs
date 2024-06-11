//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

namespace Bank_management.Brokers.Storage.Bank
{
    internal interface IBankBroker
    {
        bool MakingDeposit(decimal accountNumberForBank, decimal balance);
        decimal WithdrawMoney(decimal accountNumberForBank, decimal balance);
        decimal GetBalance(decimal accountNumberForBank);
    }
}
