using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public class ExpenseDbContext : DbContext

    {

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {

        }
        public DbSet<ExpenseEntity> Categories { get; set; }
        public DbSet<ExpenseCategoryEntity> ExpenseCategory { get; set; }
        
    }
}
