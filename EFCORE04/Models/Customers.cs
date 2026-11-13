using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Models
{
    public class Customers
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Adderss { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string Emall { get; set; }
        public string PhonNumber { get; set; }
        public string CustomersType { get; set; }
        public string Nationalld { get; set; }
        public List<AccountCustomers> AccountCustomers { get; set; }




    }
}
