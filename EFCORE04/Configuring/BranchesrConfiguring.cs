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
    public class BranchesrConfiguring : IEntityTypeConfiguration<Branche>
    {
        public void Configure(EntityTypeBuilder<Branche> builder)
        {
            builder.HasKey(b=>b.Code);


            builder.HasOne(b => b.managers)
                .WithOne(b => b.branches)
                .HasForeignKey<Branche>(b => b.managersId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
               new Branche
               {
                  Code = 1,
                   Name = "Cairo Branch",
                   Adderss = "Nasr City",
                   PhonNumer = "0223456789",
                   managersId = 1
               },
               new Branche
               {
                   Code = 2,
                   Name = "Alexandria Branch",
                   Adderss = "Smouha",
                   PhonNumer = "0345678910",
                   managersId = 2
               },
               new Branche
               {
                   Code = 3,
                   Name = "Giza Branch",
                   Adderss = "Dokki",
                   PhonNumer = "0234567890",
                   managersId = 3
               }
           );


        }
    }
}
