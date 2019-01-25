using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckoutKata
{
    public class Grocery
    {
        private decimal total = 0;


        public Dictionary<string, item> costList;
        public Dictionary<string, decimal> MarkDownList;
        public Dictionary<string, decimal> Receipt = new Dictionary<string, decimal>();
        public Dictionary<string, SpecialBuyNgetMatXPctOff> Specials= new Dictionary<string, SpecialBuyNgetMatXPctOff>();

        public Grocery()
        {
            costList = new Dictionary<string, item>();
            MarkDownList = new Dictionary<string, decimal>();
            costList.Add("soup", new item("soup", 1.25m,false));
            costList.Add("cheese",new item("cheese", 2.75m, false));
            costList.Add("beef", new item("beef", 4m, true));
            costList.Add("milk", new item("milk", 1m, false));

        }

        public decimal GetTotal()
        {
            decimal markdown;
            total = 0;
            foreach (KeyValuePair<string,decimal> LineItem in Receipt)
            {
                if (Specials.ContainsKey(LineItem.Key))
                {
                    //assume only 1 kind of special (BuyNgetM...) exists for now

                    SpecialBuyNgetMatXPctOff special = Specials[LineItem.Key];
                    decimal val = 0;
                    
                    decimal itemsLeft = LineItem.Value;
                            
                    while (itemsLeft > 0)
                    {
                        if (itemsLeft > special.M)
                        {
                            //discount the N items. The M items and the remainder (total-M-N) are regular price.
                            val += special.M;
                            itemsLeft -= special.M;
                            if(itemsLeft < special.N)
                            {
                                val+=itemsLeft * (1 - special.pct);
                                itemsLeft = 0;
                            }
                            else
                            {
                                val += special.N * (1 - special.pct);
                                itemsLeft -= special.N;
                            }
                                    
                        }
                        else
                        {
                            val += itemsLeft;
                            itemsLeft = 0;
                        }
                    }
                        
                       
                    
                    total += (costList[LineItem.Key].cost - (MarkDownList.TryGetValue(LineItem.Key, out markdown) ? markdown : 0)) * val;

                }
                else
                    total += (costList[LineItem.Key].cost - (MarkDownList.TryGetValue(LineItem.Key, out markdown) ? markdown : 0)) * LineItem.Value;
            }
            return total;
        }
        public void addItem(string name)
        {
            
            if (Receipt.ContainsKey(name))
                Receipt[name] += 1;
            else
                Receipt.Add(name, 1);
        }

        public void addItemLbs(string name, decimal weight)
        {
            if (Receipt.ContainsKey(name))
                Receipt[name] += weight;
            else
                Receipt.Add(name, weight);
        }
       
        public void removeItem(string name, decimal weight=1)
        {
            Receipt[name] -= weight;
        }

        public static void Main(string[] args)
        {
            Grocery grocery = new Grocery();
            grocery.AddSpecialBuyNgetMatXPctOff("cheese", 2, 1, .15m);
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            decimal test = grocery.GetTotal();
        }

        public void addMarkDown(string name, decimal markdown)
        {
            MarkDownList.Add(name, markdown);
        }
        public struct SpecialBuyNgetMatXPctOff
        {
            public int N;
            public int M;
            public string name;
            public decimal pct;
            public SpecialBuyNgetMatXPctOff(string name, int M, int N,  decimal pct)
            {
                this.N = N;
                this.M = M;
                this.name = name;
                this.pct = pct;
            }

        }
        public struct item
        {
            public string name;
            public decimal cost;
            public bool isPerLb;
            public item(string name, decimal cost, bool isPerLb)
            {
                this.name = name;
                this.cost = cost;
                this.isPerLb = isPerLb;
            }
        }
        public void AddSpecialBuyNgetMatXPctOff(string name, int M, int N, decimal pct)
        {
             SpecialBuyNgetMatXPctOff special = new SpecialBuyNgetMatXPctOff( name, M, N, pct);
            if (Specials.ContainsKey(name))
                Specials[name] = special;
            else
                Specials.Add(name, special);
        }
    }
}
