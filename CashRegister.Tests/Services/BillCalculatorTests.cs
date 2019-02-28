using System;
using CashRegister.Model.Bill;
using CashRegister.Model.Catalog;
using CashRegister.Discounts;
using CashRegister.Services;
using Moq;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class BillCalculatorTests
    {
        [Test]
        public void GetPrice_OneProductWithoutDiscounts_ShouldReturnValidPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem("apple", 10m, 1.5m)
            });
            var price = billCalculator.GetFinalAmount(bill, null);

            Assert.AreEqual(15, price);
        }

        [Test]
        public void GetPrice_OneProductWithDiscounts_ShouldReturnDiscountedPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount("apple"))
                .Returns(new BulkDiscount("apple", 5, 1));

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem("apple", 10m, 6m)
            });
            var price = billCalculator.GetFinalAmount(bill, null);

            Assert.AreEqual(50, price);
        }

        [Test]
        public void GetPrice_OneProductWithNotFittedCoupon_ShouldReturnNormalPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem("chocolate", 25m, 4m)
            });
            var coupon = new Coupon(110, 10);
            var price = billCalculator.GetFinalAmount(bill, new [] { coupon });

            Assert.AreEqual(100, price);
        }

        [Test]
        public void GetPrice_OneProductWithFittedCoupon_ShouldReturnDiscountedPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem("chocolate", 25m, 4m)
            });
            var coupon = new Coupon(100, 10);
            var price = billCalculator.GetFinalAmount(bill, new [] { coupon });

            Assert.AreEqual(90, price);
        }
    }
}