using System;
using Grocery.Data.Bill;
using Grocery.Data.Catalog;
using Grocery.Discounts;
using Grocery.Services;
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
            mockCatalogService
                .Setup(s => s.GetItemPrice("apple"))
                .Returns(10m);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem(new Item("apple"), 1.5m)
            });
            var price = billCalculator.GetPrice(bill, null);

            Assert.AreEqual(15, price);
        }

        [Test]
        public void GetPrice_OneProductWithDiscounts_ShouldReturnDiscountedPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount("apple"))
                .Returns(new BulkDiscount("apple", 5, 1));
            mockCatalogService
                .Setup(s => s.GetItemPrice("apple"))
                .Returns(10m);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem(new Item("apple"), 6m)
            });
            var price = billCalculator.GetPrice(bill, null);

            Assert.AreEqual(50, price);
        }

        [Test]
        public void GetPrice_OneProductWithNotFittedCoupon_ShouldReturnNormalPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);
            mockCatalogService
                .Setup(s => s.GetItemPrice("chocolate"))
                .Returns(25m);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem(new Item("chocolate"), 4m)
            });
            var coupon = new Coupon(110, 10);
            var price = billCalculator.GetPrice(bill, new [] { coupon });

            Assert.AreEqual(100, price);
        }

        [Test]
        public void GetPrice_OneProductWithFittedCoupon_ShouldReturnDiscountedPrice()
        {
            var mockCatalogService = new Mock<ICatalogService>();
            mockCatalogService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);
            mockCatalogService
                .Setup(s => s.GetItemPrice("chocolate"))
                .Returns(25m);

            var billCalculator = new BillCalculator(mockCatalogService.Object);

            var bill = new Bill(new [] {
                new LineItem(new Item("chocolate"), 4m)
            });
            var coupon = new Coupon(100, 10);
            var price = billCalculator.GetPrice(bill, new [] { coupon });

            Assert.AreEqual(90, price);
        }
    }
}