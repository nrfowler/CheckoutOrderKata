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


        public Dictionary<string, decimal> costList;

        public Grocery()
        {
            costList = new Dictionary<string, decimal>();
            costList.Add("soup", 1.25m);
            costList.Add("cheese", 2.75m);
        }

        public decimal getTotal()
        {
            return total;
        }
        public decimal addItem(string name)
        {
            total += costList[name];
            return costList[name];
        }
       
        public void removeItem(string name)
        {
            total -= costList[name];
        }
        
        public static void Main(string[] args)
        {
          
        }
    }
}
