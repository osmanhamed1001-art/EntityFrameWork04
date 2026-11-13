using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Models
{
    public class AccountCustomers
    {

        public int customersId { get; set; }

        public Customers customers {  get; set; }

        public int accountsId { get; set; }

        public Accounts accounts { get; set; }

        public string OwnershipType { get; set; }
        public DateTime OwnershipStartdata { get; set; }
        public string AccountStatus { get; set; }


    }
}
