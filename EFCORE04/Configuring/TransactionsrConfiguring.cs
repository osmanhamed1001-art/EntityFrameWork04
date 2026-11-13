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
    internal class TransactionsrConfiguring : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.HasKey(t=>t.TransactionsNumber);



                    builder.HasData(
            new Transactions
            {
                TransactionsNumber = 1,
                TransactionData = new DateTime(2024, 1, 20),
                Amount = 5000m,
                TransactionType = "Deposit",
                Note = "Cash deposit",
                GetAccountsId = 1001
            },
            new Transactions
            {
                TransactionsNumber = 2,
                TransactionData = new DateTime(2024, 2, 15),
                Amount = 2000m,
                TransactionType = "Withdrawal",
                Note = "ATM withdrawal",
                GetAccountsId = 1002
            },
            new Transactions
            {
                TransactionsNumber = 3,
                TransactionData = new DateTime(2024, 3, 10),
                Amount = 3000m,
                TransactionType = "Deposit",
                Note = "Bank transfer",
                GetAccountsId = 1003
            }
        );



        }
    }
}
