
using System;
using CashRegister.Model.Bill;
using CashRegister.Model.Catalog;
using NUnit.Framework;

namespace Tests
{
    public class BillTests
    {
        [Test]
        public void CreateBill_WithNullListItems_ThrowException()
        {
            TestDelegate action = () => new Bill(null);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void CreateBill_WithEmptyListItems_ThrowException()
        {
            TestDelegate action = () => new Bill(new LineItem[0]);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void CreateBill_WithValidListItems_SuccessfulyCreate()
        {
            var bill = new Bill(new [] { new LineItem("apple", 10, 5) });

            Assert.AreEqual(1, bill.LineItems.Count);
            Assert.AreEqual("apple", bill.LineItems[0].Name);
            Assert.AreEqual(5, bill.LineItems[0].Quantity);
            Assert.AreEqual(10, bill.LineItems[0].Price);
        }
    }
}