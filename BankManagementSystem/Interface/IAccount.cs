﻿
namespace BankManagementSystem.Interface
{
    public interface IAccount
    {
        void Deposit(long accountNumber, double amount);
        void Withdraw(long accountNumber, string password, double amount);
        void CheckBalance(long accountNumber,string password);
        void MoneyTransfer(long senderAccountNumber, long recipientAccountNumber, string password, string IFSCCode);
        void ApplyAtmCard(long accountNumber, string password);
    }
}
