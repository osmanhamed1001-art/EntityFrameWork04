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
    internal class CustomerConfiguring : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(C => C.Id);

            builder.HasData(
             new Customers
             {
                 Id = 1,
                 FullName = "Ahmed Mohamed",
                 Adderss = "Cairo",
                 DataOfBirth = new DateTime(1995, 5, 10),
                 Emall = "ahmed@gmail.com",
                 PhonNumber = "01012345678",
                 CustomersType = "Regular",
                 Nationalld = "29505101234567"
             }, new Customers
             {
                 Id = 3,
                 FullName = "Omar Hassan",
                 Adderss = "Giza",
                 DataOfBirth = new DateTime(1992, 3, 20),
                 Emall = "omar@gmail.com",
                 PhonNumber = "01212345678",
                 CustomersType = "Regular",
                 Nationalld = "29203201234567"
             }  ,
             new Customers
             {
                 Id = 2,
                 FullName = "Mohamed Ali",
                 Adderss = "Alexandria",
                 DataOfBirth = new DateTime(1998, 8, 15),
                 Emall = "mohamed@gmail.com",
                 PhonNumber = "01112345678",
                 CustomersType = "VIP",
                 Nationalld = "29808151234567"
             }




             );
        }
    }
}
