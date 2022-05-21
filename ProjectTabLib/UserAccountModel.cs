using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTabLib
{
    public class UserAccountModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Account_Name { get; set; }
        public double Balance { get; set; }
        public bool Status { get; set; }
    }
}
