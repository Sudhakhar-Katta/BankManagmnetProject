using Microsoft.AspNetCore.Identity;

namespace BankManagement.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    } 
}
