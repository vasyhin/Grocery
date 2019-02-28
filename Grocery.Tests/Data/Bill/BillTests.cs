
using System;
using Grocery.Data.Bill;
using Grocery.Data.Catalog;
using NUnit.Framework;

namespace Tests
{
    public class BillTests
    {
        [Test]
        public void InterationTest()
        {
            TestDelegate action = () => new Bill(null);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void InterationTest2()
        {
            TestDelegate action = () => new Bill(new LineItem[0]);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void InterationTest3()
        {
            var bill = new Bill(new [] { new LineItem(new Item("test"), 5) });

            Assert.AreEqual(1, bill.LineItems.Count);
            Assert.AreEqual("test", bill.LineItems[0].Item.Name);
            Assert.AreEqual(5, bill.LineItems[0].Quantity);
        }
    }
}