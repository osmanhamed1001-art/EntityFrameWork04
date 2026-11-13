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
    internal class ManagersrConfiguring : IEntityTypeConfiguration<Managers>
    {
        public void Configure(EntityTypeBuilder<Managers> builder)
        {
            builder.HasKey(x => x.Id);

                          builder.HasData(
            new Managers
            {
                Id = 1,
                FullName = "Ahmed Mohamed",
                Emall = "ahmed@gmail.com",
                PhonNumber = "01012345678",
                HireData = new DateTime(2020, 5, 10)
            },
            new Managers
            {
                Id = 2,
                FullName = "Mohamed Ali",
                Emall = "mohamed@gmail.com",
                PhonNumber = "01112345678",
                HireData = new DateTime(2021, 3, 15)
            },
            new Managers
            {
                Id = 3,
                FullName = "Omar Hassan",
                Emall = "omar@gmail.com",
                PhonNumber = "01212345678",
                HireData = new DateTime(2022, 7, 20)
            }
            );
            

        }
    }
}
