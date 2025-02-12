using BankManagement.Core.Entities;
using BankManagement.Core.Interfaces;
using BankManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;

        public TransactionService(DataContext context)
        {
            _context = context;
        }

        public List<Transaction> GetTransactionsByUser(string userId)
        {
            return _context.Transactions.Where(t => t.UserAccount.UserId == userId).ToList();
        }

        public decimal Deposit(int userAccountId, decimal amount)
        {
            var account = _context.Accounts.Find(userAccountId);
            if (account == null) return -1;

            account.Balance += amount;
            _context.Transactions.Add(new Transaction
            {
                UserAccountId = userAccountId,
                Amount = amount,
                TransactionType = "Deposit",
                Timestamp = DateTime.UtcNow
            });

            _context.SaveChanges();
            return account.Balance;
        }

        public decimal Withdraw(int userAccountId, decimal amount)
        {
            var account = _context.Accounts.Find(userAccountId);
            if (account == null || account.Balance < amount) return -1;

            account.Balance -= amount;
            _context.Transactions.Add(new Transaction
            {
                UserAccountId = userAccountId,
                Amount = amount,
                TransactionType = "Withdrawal",
                Timestamp = DateTime.UtcNow
            });

            _context.SaveChanges();
            return account.Balance;
        }
    }
}
