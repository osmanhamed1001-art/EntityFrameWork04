using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Models
{
    public class Branche
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Adderss { get; set; }
        public string PhonNumer { get; set; }
        public int managersId { get; set; }
        public Managers managers { get; set; }
        public List< Accounts> acc { get; set; }
       
    }
}
