using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Models
{
    public class Managers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Emall { get; set; }
        public string PhonNumber { get; set; }
        public DateTime HireData { get; set; }
        public Branche branches { get; set; }


    }
}
