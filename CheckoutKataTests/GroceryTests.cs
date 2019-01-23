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
    }
}