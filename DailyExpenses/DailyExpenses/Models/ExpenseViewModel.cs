using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyExpenses.Models
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public DateTime Updated_at { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }


    }
}