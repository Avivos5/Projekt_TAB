using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTabLib
{
    public class TransactionDatagridModel
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Category_Id { get; set; }
        public int Account_Id { get; set; }
        public string DateTime { get; set; }
        public string Name { get; set; }
        public double Transaction_Amount { get; set; }
        public bool Income { get; set; }
        public double Current_Amount { get; set; }
        public string Category_Name { get; set; }
        public string ColorSet { get; set; }
        public string Account_Name { get; set; }
    }
}
