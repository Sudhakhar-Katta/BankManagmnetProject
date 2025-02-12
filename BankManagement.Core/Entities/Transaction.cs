namespace BankManagement.Core.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }  // Foreign Key to UserAccount
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string TransactionType { get; set; }  // "Deposit" or "Withdrawal"

        // Navigation Property (EF Core)
        public UserAccount UserAccount { get; set; }
    }
}
