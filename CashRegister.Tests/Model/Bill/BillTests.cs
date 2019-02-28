using System;
using NUnit.Framework;
using CashRegister.Model.Bill;
using BillModel = CashRegister.Model.Bill.Bill;

namespace CashRegisterTests.Model.Bill
{
    public class BillTests
    {
        [Test]
        public void CreateBill_WithNullListItems_ThrowException()
        {
            TestDelegate action = () => new BillModel(null);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void CreateBill_WithEmptyListItems_ThrowException()
        {
            TestDelegate action = () => new BillModel(new LineItem[0]);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void CreateBill_WithValidListItems_SuccessfulyCreate()
        {
            var bill = new BillModel(new [] { new LineItem("apple", 10, 5) });

            Assert.AreEqual(1, bill.LineItems.Count);
            Assert.AreEqual("apple", bill.LineItems[0].Name);
            Assert.AreEqual(5, bill.LineItems[0].Quantity);
            Assert.AreEqual(10, bill.LineItems[0].Price);
        }
    }
}