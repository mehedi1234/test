using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyExpenses.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public string Mpan { get; set; }
        public string Mprn { get; set; }
        public decimal Savings { get; set; }
        public decimal GasSpendPrice { get; set; }
        public decimal ElectricitySpendPrice { get; set; }




    }
}