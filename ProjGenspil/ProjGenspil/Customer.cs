using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    internal class Customer
    {
        private string customerName;
        private int customerPhone;

        public string CustomerName { get => customerName; set => customerName = value; }
        public int CustomerPhone { get => customerPhone; set => customerPhone = value; }
    }
}
