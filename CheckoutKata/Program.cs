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
        public Dictionary<string, Special> Specials = new Dictionary<string, Special>();

        public Grocery()
        {
            costList = new Dictionary<string, item>();
            MarkDownList = new Dictionary<string, decimal>();
            costList.Add("soup", new item("soup", 1.25m, false));
            costList.Add("cheese", new item("cheese", 2.75m, false));
            costList.Add("beef", new item("beef", 4m, true));
            costList.Add("milk", new item("milk", 1m, false));

        }

        public decimal GetTotal()
        {
            decimal markdown;
            total = 0;
            foreach (KeyValuePair<string, decimal> LineItem in Receipt)
            {
                if (Specials.ContainsKey(LineItem.Key))
                {
                    decimal val = 0;
                    decimal itemsLeft = LineItem.Value;
                    Special GenericSpecial = Specials[LineItem.Key];
                    if (GenericSpecial.GetType() == typeof(SpecialBuyNgetMatXPctOff))
                    {
                        SpecialBuyNgetMatXPctOff special = (SpecialBuyNgetMatXPctOff)GenericSpecial;
                        while (itemsLeft > 0)
                        {
                            if ((itemsLeft > special.m) && (LineItem.Value-itemsLeft<special.limit))
                            {
                                val += special.m;
                                itemsLeft -= special.m;
                                if (itemsLeft < special.n)
                                {
                                    val += itemsLeft * (1 - special.pct);
                                    itemsLeft = 0;
                                }
                                else
                                {
                                    val += special.n * (1 - special.pct);
                                    itemsLeft -= special.n;
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
                    else if (GenericSpecial.GetType() == typeof(SpecialNForX))
                    {
                        SpecialNForX special = (SpecialNForX)GenericSpecial;
                        while ((itemsLeft >= special.n) && (LineItem.Value - itemsLeft < special.limit))
                        {
                            itemsLeft -= special.n;
                            total += (special.cost - (MarkDownList.TryGetValue(LineItem.Key, out markdown) ? markdown : 0) )* special.n;
                        }
                        total += (costList[LineItem.Key].cost - (MarkDownList.TryGetValue(LineItem.Key, out markdown) ? markdown : 0)) * itemsLeft;

                    }
                }
                
                else
                    total += (costList[LineItem.Key].cost - (MarkDownList.TryGetValue(LineItem.Key, out markdown) ? markdown : 0)) * LineItem.Value;
            }
            return total;
        }
        public void addItem(string name, int amt=1)
        {

            if (Receipt.ContainsKey(name))
                Receipt[name] += amt;
            else
                Receipt.Add(name, amt);
        }

        public void addItemLbs(string name, decimal weight)
        {
            if (Receipt.ContainsKey(name))
                Receipt[name] += weight;
            else
                Receipt.Add(name, weight);
        }

        public void removeItem(string name, decimal weight = 1)
        {
            Receipt[name] -= weight;
        }

        public static void Main(string[] args)
        {

        }

        public void addMarkDown(string name, decimal markdown)
        {
            MarkDownList.Add(name, markdown);
        }
        

        public void AddSpecialNForX(string name, int N, decimal X, int limit = Int16.MaxValue)
        {
            SpecialNForX special = new SpecialNForX(name, N, X);
            special.limit = limit;
            if (Specials.ContainsKey(name))
                Specials[name] = special;
            else
                Specials.Add(name, special);
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
        public void AddSpecialBuyNgetMatXPctOff(string name, int M, int N, decimal pct, int limit=Int16.MaxValue)
        {
            SpecialBuyNgetMatXPctOff special = new SpecialBuyNgetMatXPctOff(name, M, N, pct);
            special.limit = limit;
            if (Specials.ContainsKey(name))
                Specials[name] = special;
            else
                Specials.Add(name, special);
        }
    }
    public class Special
    {
        public int limit;

    }
    public class SpecialBuyNgetMatXPctOff : Special
    {
        public string name;
        public int m;
        public int n;
        public decimal pct;

        public SpecialBuyNgetMatXPctOff(string name, int m, int n, decimal pct)
        {
            this.name = name;
            this.m = m;
            this.n = n;
            this.pct = pct;
        }
    }
    public class SpecialNForX : Special
    {
        private string name;
        public int n;
        public decimal cost;

        public SpecialNForX(string name, int n, decimal cost)
        {
            this.name = name;
            this.n = n;
            this.cost = cost;
        }
    }
}
