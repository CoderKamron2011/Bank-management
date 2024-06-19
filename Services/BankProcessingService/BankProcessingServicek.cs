//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

using Bank_management.Brokers.Storage.Register;
using Bank_management.Model;
using Bank_management.Services.BankProcessingService;
using Bank_management.Services.Foundation.Banks;
using Bank_management.Services.Foundation.Banks.Customers;
using Bank_management.Services.Foundation.Registrs;
using static Bank_management.Services.BankProcessingService.IBankProcessingService;

namespace Bank_management.Services.BankProcessingService
{
    internal class BankProcessingServicek
    {
        internal class BankProcessingsService : IBankProcessingsService
        {
            private readonly IRegisterService registerService;
            private readonly IBankService bankService;
            private readonly ICustomerService customerService;

            public BankProcessingsService(
                IRegisterService registerService,
                IBankService bankService,
                ICustomerService customerService)
            {
                this.registerService = registerService;
                this.bankService = bankService;
                this.customerService = customerService;
            }

            public bool DeleteForClient(decimal accountNumber) =>
                this.customerService.DeleteClient(accountNumber);

            public decimal GetBalance(decimal accountNumberForBank) =>
                this.bankService.GetBalanceInBank(accountNumberForBank);

            public decimal GetMoney(decimal accountNumberForBank, decimal balance) =>
                this.bankService.GetMoney(accountNumberForBank, balance);

            public bool LogInUser(User user) =>
                this.registerService.LogIn(user);

            public bool PostDeposit(decimal accountNumberForBank, decimal balance) =>
                this.bankService.AddDeposit(accountNumberForBank, balance);

            public bool PostForClient(Customer customer) =>
                this.customerService.CreateClient(customer);

            public User PostUser(User user) =>
                this.registerService.SignUp(user);

            public bool TransferMoneyBetweenAccountsForClient(
                decimal firstAccountNumber,
                decimal secondAccountNumber,
                decimal money) =>
                this.customerService.TransferMoneyBetweenClients(
                                firstAccountNumber,
                                secondAccountNumber,
                                money);
        }
    }
}
