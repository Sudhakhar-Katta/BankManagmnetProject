using BankManagement.Core.Entities;

namespace BankManagement.Core.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactionsByUser(string userId);
        decimal Deposit(int userAccountId, decimal amount);
        decimal Withdraw(int userAccountId, decimal amount);
    }
}
