using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests
{
    [TestClass()]
    public class GroceryTests
    {
        [TestMethod()]
        public void GetTotalTest()
        {
            Grocery grocery = new Grocery();
            Assert.AreEqual(0, grocery.getTotal());
        }
        [TestMethod()]
        public void AddItemTest()
        {
            Grocery grocery = new Grocery();
            grocery.addItem("soup");
            Assert.AreEqual(1.25m, grocery.getTotal());
        }
        [TestMethod()]
        public void RemoveItemTest()
        {
            Grocery grocery = new Grocery();
            grocery.addItem("soup");
            Assert.AreEqual(1.25m, grocery.getTotal());
            grocery.addItem("cheese");
            Assert.AreEqual(4m, grocery.getTotal());
            grocery.removeItem("soup");
            Assert.AreEqual(2.75m, grocery.getTotal());
            grocery.removeItem("cheese");
            Assert.AreEqual(0m, grocery.getTotal());
        }
        [TestMethod()]
        public void AddItemLbsTest()
        {
            Grocery grocery = new Grocery();
            grocery.addItemLbs("beef", 2.5m);
            Assert.AreEqual(10m, grocery.getTotal());
        }
        [TestMethod()]
        public void RemoveItemLbsTest()
        {
            Grocery grocery = new Grocery();
            grocery.addItemLbs("beef", 2.5m);
            grocery.removeItem("beef", .10m);
            Assert.AreEqual(9.6m, grocery.getTotal());
        }
        [TestMethod()]
        public void SupportMarkdownTest()
        {
            Grocery grocery = new Grocery();
            grocery.addMarkDown("beef", .15m);
            grocery.addItemLbs("beef", 1m);
            Assert.AreEqual(3.85m, grocery.getTotal());
        }
        //Buy M items get N at %X off.
        [TestMethod()]
        public void BuyNgetMatXPctOffTest()
        {
            Grocery grocery = new Grocery();
            grocery.AddSpecialBuyNgetMatXPctOff("cheese",2 ,1, .15m);
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            Assert.AreEqual(7.8375m, grocery.getTotal());
        }
        //Buy M items get N at %X off-with multiples of M and N.
        [TestMethod()]
        public void BuyNgetMatXPctOffTestWithMultiples()
        {
            Grocery grocery = new Grocery();
            grocery.AddSpecialBuyNgetMatXPctOff("cheese", 2, 1, .15m);
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            grocery.addItem("cheese");
            Assert.AreEqual(15.675m, grocery.getTotal());
            grocery.addItem("cheese");
            //Should add a cheese at normal price
            Assert.AreEqual(18.425m, grocery.getTotal());
            grocery.addItem("cheese");
            //Should add a cheese at normal price
            Assert.AreEqual(21.175m, grocery.getTotal());
            grocery.addItem("cheese");
            //Should add one discounted cheese
            Assert.AreEqual(23.5125m, grocery.getTotal());

        }
    }
}