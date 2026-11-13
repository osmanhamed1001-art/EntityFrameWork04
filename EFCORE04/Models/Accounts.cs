using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Models
{
    public class Accounts
    {

        public int AccounNumber { get; set; }
        public decimal CrrentBalace { get; set; }
        public string AccounType { get; set; }
        public DateTime OpeingData { get; set; }
        public int BraId { get; set; }
        public Branche Bra { get; set; }

        public List <AccountCustomers> AccountCustomers { get; set; }
        public List <Transactions> Trans { get; set; }


    }
}
