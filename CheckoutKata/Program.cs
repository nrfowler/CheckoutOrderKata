using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Grocery
    {
        private decimal total = 0;

        public decimal getTotal()
        {
            return total;
        }
        public void addItem(string name, decimal cost)
        {
            total += cost;
        }
        static void Main(string[] args)
        {
        }
    }
}
