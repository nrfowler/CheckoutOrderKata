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
            costList.Add("beef", 4m);
        }

        public decimal getTotal()
        {
            return total;
        }
        public void addItem(string name)
        {
            total += costList[name];
        }

        public void addItemLbs(string name, decimal weight)
        {
            total += costList[name]*weight;
        }
       
        public void removeItem(string name, decimal weight=1)
        {
            total -= costList[name]*weight;
        }

        public static void Main(string[] args)
        {
          
        }
    }
}
