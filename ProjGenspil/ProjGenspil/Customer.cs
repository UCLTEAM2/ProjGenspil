using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjGenspil
{
    class Customer
    {
        private string _customerName;
        private int _customerPhone;

        public string CustomerName { get => _customerName; set => _customerName = value; }
        public int CustomerPhone { get => _customerPhone; set => _customerPhone = value; }

        public Customer(string customerName, int customerPhone)
        {
            CustomerName = customerName;
            CustomerPhone = customerPhone;
        }
    }
}
