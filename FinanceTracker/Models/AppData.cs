using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    public class AppData
    {
        public List<User> Users { get; set; } = new();
        public List<Debt> Debts { get; set; } = new();
        public List<TransactionModels> Transactionpage { get; set; } = new();
    }
}
