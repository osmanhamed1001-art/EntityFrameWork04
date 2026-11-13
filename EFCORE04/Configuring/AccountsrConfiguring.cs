using EFCORE04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Configuring
{
    internal class AccountsrConfiguring : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(a => a.AccounNumber);


            builder.HasOne(a=>a.Bra)
                .WithMany(a=>a.acc)
                .HasForeignKey(a=>a.BraId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(a => a.Trans)
                .WithOne(a => a.GetAccounts)
                .HasForeignKey(a => a.GetAccountsId)
                .OnDelete(DeleteBehavior.NoAction);



            builder.HasData(
               new Accounts
               {
                   AccounNumber = 1001,
                   CrrentBalace = 15000m,
                   AccounType = "Saving",
                   OpeingData = new DateTime(2024, 1, 15),
                   BraId = 1
               },
               new Accounts
               {
                   AccounNumber = 1002,
                   CrrentBalace = 25000m,
                   AccounType = "Current",
                              OpeingData = new DateTime(2024, 3, 20),
                   BraId = 2
               },
               new Accounts
               {
                   AccounNumber = 1003,
                   CrrentBalace = 10000m,
                   AccounType = "Saving",
                   OpeingData = new DateTime(2024, 6, 10),
                   BraId = 1
               }
           );

        }
    }
}
