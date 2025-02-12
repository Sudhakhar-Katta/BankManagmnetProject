using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserAccount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int AccountID { get; set; }

    public string UserID { get; set; }

    public ApplicationUser User { get; set; }

    public string Name { get; set; }

    public decimal Balance { get; set; } = 0.0m;

    public bool IsActive { get; set; } = true;
}
