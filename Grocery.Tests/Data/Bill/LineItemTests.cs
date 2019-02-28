
using System;
using Grocery.Data.Bill;
using Grocery.Data.Catalog;
using NUnit.Framework;

namespace Tests
{
    public class LineItemTests
    {
        [Test]
        public void CreateLineItem_WithNullItem_ThrowException()
        {
            TestDelegate action = () => new LineItem(null, 10);
            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void CreateLineItem_WithNegativeQuantity_ThrowException()
        {
            TestDelegate action = () => new LineItem(new Item("test"), -5);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void CreateLineItem_WithValidItem_SuccessfulyCreate()
        {
            var lineItem = new LineItem(new Item("test"), 5);

            Assert.AreEqual("test", lineItem.Item.Name);
            Assert.AreEqual(5, lineItem.Quantity);
        }
    }
}