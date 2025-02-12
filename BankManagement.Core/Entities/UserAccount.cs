namespace BankManagement.Core.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // Foreign Key to ApplicationUser
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property (EF Core)
        public ApplicationUser User { get; set; }
    }
}
