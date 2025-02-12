using BankManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace BankManagement.Infrastructure.Data {

    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<UserAccount> Accounts { get;  set; }
        public DbSet <Transaction> Transactions { get; set; } 

    
    
    }
}