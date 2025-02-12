using System.ComponentModel.DataAnnotations;

public class Transaction { 

	public int TransactionId { get; set; }

	public int AccountId { get; set; }

	public UserAccount Account { get; set; }

	public string Type { get; set; } // Despoit or Withdraw

	public decimal Amount { get; set; }

	public DateTime Timestamp { get; set; } = DateTime.UtcNow;// exact time of object creation
}