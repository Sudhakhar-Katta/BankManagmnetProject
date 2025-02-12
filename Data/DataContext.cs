namespace BankManagmentAPI.Data  // ✅ Ensure this matches your Program.cs
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserAccount> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

/*
Data Context is like a Database and is inherting from
IdentityDB, and will automatically store usernames,emails, 
and password
*/