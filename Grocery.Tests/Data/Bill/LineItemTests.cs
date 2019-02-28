
using System;
using Grocery.Data.Bill;
using Grocery.Data.Catalog;
using NUnit.Framework;

namespace Tests
{
    public class LineItemTests
    {
        [Test]
        public void InterationTest()
        {
            TestDelegate action = () => new LineItem(null, 10);
            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void InterationTest2()
        {
            TestDelegate action = () => new LineItem(new Item("test"), -5);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void InterationTest3()
        {
            var lineItem = new LineItem(new Item("test"), 5);

            Assert.AreEqual("test", lineItem.Item.Name);
            Assert.AreEqual(5, lineItem.Quantity);
        }
    }
}