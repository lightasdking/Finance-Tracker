using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Models
{
    public class TransactionModels
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
