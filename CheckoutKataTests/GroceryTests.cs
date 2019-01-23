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
            grocery.addItem("soup", 1.25m);
            Assert.AreEqual(1.25m, grocery.getTotal());
            grocery.addItem("cheese",2.75m);
            Assert.AreEqual(4m, grocery.getTotal());

        }
        [TestMethod()]
        public void RemoveItemTest()
        {
            Grocery grocery = new Grocery();
            grocery.addItem("soup", 1.25m);
            Assert.AreEqual(1.25m, grocery.getTotal());
            grocery.addItem("cheese", 2.75m);
            Assert.AreEqual(4m, grocery.getTotal());
            grocery.removeItem("soup", 1.25m);
            Assert.AreEqual(2.75m, grocery.getTotal());
            grocery.removeItem("cheese", 2.75m);
            Assert.AreEqual(0m, grocery.getTotal());
        }
    }
}