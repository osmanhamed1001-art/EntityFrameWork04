using EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFcore04;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<AccountCustomers> AccountCustomers { get; set; }
        public DbSet<Branche> Branches { get; set; }

    }
}
