using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE04.Models
{
    public class Transactions
    {
        public int TransactionsNumber { get; set; }
        public DateTime TransactionData { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Note { get; set; }
        public int GetAccountsId {  get; set; }
        public Accounts GetAccounts { get; set; }
        
    }
}
