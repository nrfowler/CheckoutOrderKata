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
        public Dictionary<string, decimal> MarkDownList;

        public Grocery()
        {
            costList = new Dictionary<string, decimal>();
            MarkDownList = new Dictionary<string, decimal>();
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
            decimal markdown;
            
            total += costList[name] - (MarkDownList.TryGetValue(name, out markdown) ? markdown : 0);
        }

        public void addItemLbs(string name, decimal weight)
        {
            decimal markdown;
            total += (costList[name]- (MarkDownList.TryGetValue(name, out markdown) ? markdown : 0)) *weight;
        }
       
        public void removeItem(string name, decimal weight=1)
        {
            total -= costList[name]*weight;
        }

        public static void Main(string[] args)
        {
          
        }

        public void addMarkDown(string name, decimal markdown)
        {
            MarkDownList.Add(name, markdown);
        }
    }
}
