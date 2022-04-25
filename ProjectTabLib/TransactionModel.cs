using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTabLib
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public string DateTime { get; set; }
        public string Name { get; set; }
        public double TransactionAmount { get; set; }
        public bool Income { get; set; }
        public double CurrentAmount { get; set; }

    }
}
