using Microsoft.EntityFrameworkCore;
using BudgetApp.Models;
using System.Collections.Generic;

namespace BudgetApp
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<Income> Incomes => Set<Income>();
    }
}
