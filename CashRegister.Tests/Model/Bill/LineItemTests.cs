using System;
using CashRegister.Model.Bill;
using NUnit.Framework;

namespace CashRegister.Tests.Model.Bill
{
    public class LineItemTests
    {
        [Test]
        public void CreateLineItem_WithNegativeQuantity_ThrowException()
        {
            TestDelegate action = () => new LineItem("Cheerios", 10m, -5);
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Test]
        public void CreateLineItem_WithValidItem_SuccessfulyCreate()
        {
            var lineItem = new LineItem("Cheerios", 10m, 5);

            Assert.AreEqual("Cheerios", lineItem.Name);
            Assert.AreEqual(5, lineItem.Quantity);
            Assert.AreEqual(10m, lineItem.Price);
        }
    }
}