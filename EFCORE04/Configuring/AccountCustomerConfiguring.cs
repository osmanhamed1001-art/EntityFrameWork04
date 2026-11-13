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
    internal class AccountCustomerConfiguring : IEntityTypeConfiguration<AccountCustomers>
    {
        public void Configure(EntityTypeBuilder<AccountCustomers> builder)
        {
            builder.HasKey(ac => new { ac.customersId, ac.accountsId });


            builder.HasOne(ac=>ac.accounts)
                .WithMany(ac=>ac.AccountCustomers)
                .HasForeignKey(ac=>ac.accountsId);


            builder.HasOne(ac => ac.customers)
                .WithMany(ac => ac.AccountCustomers)
                .HasForeignKey(ac => ac.customersId);

                   builder.HasData(
            new AccountCustomers
            {
                customersId = 1,
                accountsId = 1001,
                OwnershipType = "Primary",
                OwnershipStartdata = new DateTime(2024, 1, 15),
                AccountStatus = "Active"
            },
            new AccountCustomers
            {
                customersId = 2,
                accountsId = 1002,
                OwnershipType = "Primary",
                OwnershipStartdata = new DateTime(2024, 3, 20),
                AccountStatus = "Active"
            },
            new AccountCustomers
            {
                customersId = 3,
                accountsId = 1003,
                OwnershipType = "Joint",
                OwnershipStartdata = new DateTime(2024, 6, 10),
                AccountStatus = "Active"
            }
        );





        }
    }
}
