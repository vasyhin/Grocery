
using System;
using CashRegister.Model.Bill;
using CashRegister.Model.Catalog;
using NUnit.Framework;

namespace Tests
{
    public class LineItemTests
    {
        [Test]
        public void CreateLineItem_WithNegativeQuantity_ThrowException()
        {
            TestDelegate action = () => new LineItem("test", 10m, -5);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void CreateLineItem_WithValidItem_SuccessfulyCreate()
        {
            var lineItem = new LineItem("test", 10m, 5);

            Assert.AreEqual("test", lineItem.Name);
            Assert.AreEqual(5, lineItem.Quantity);
            Assert.AreEqual(10m, lineItem.Price);
        }
    }
}