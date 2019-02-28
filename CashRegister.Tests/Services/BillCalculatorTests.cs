using CashRegister.Model.Bill;
using CashRegister.Model.Discounts;
using CashRegister.Services;
using Moq;
using NUnit.Framework;
using BillModel = CashRegister.Model.Bill.Bill;

namespace CashRegister.Tests.Services
{
    public class BillCalculatorTests
    {
        [Test]
        public void GetPrice_OneProductWithoutDiscounts_ShouldReturnValidPrice()
        {
            var mockBulkDiscountService = new Mock<IBulkDiscountService>();
            mockBulkDiscountService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);

            var billCalculator = new BillCalculator(mockBulkDiscountService.Object);

            var bill = new BillModel(new [] {
                new LineItem("Apples", 10m, 1.5m)
            });
            var price = billCalculator.GetFinalAmount(bill, null);

            Assert.AreEqual(15, price);
        }

        [Test]
        public void GetPrice_OneProductWithDiscounts_ShouldReturnDiscountedPrice()
        {
            var mockBulkDiscountService = new Mock<IBulkDiscountService>();
            mockBulkDiscountService
                .Setup(s => s.GetBulkDiscount("Cheerios"))
                .Returns(new BulkDiscount("Cheerios", 5, 1));

            var billCalculator = new BillCalculator(mockBulkDiscountService.Object);

            var bill = new BillModel(new[] {
                new LineItem("Cheerios", 10m, 6m)
            });
            var price = billCalculator.GetFinalAmount(bill, null);

            Assert.AreEqual(50, price);
        }

        [Test]
        public void GetPrice_OneProductWithDoubledDiscounts_ShouldReturnDoubleAppliedDiscountPrice()
        {
            var mockBulkDiscountService = new Mock<IBulkDiscountService>();
            mockBulkDiscountService
                .Setup(s => s.GetBulkDiscount("Cheerios"))
                .Returns(new BulkDiscount("Cheerios", 5, 1));

            var billCalculator = new BillCalculator(mockBulkDiscountService.Object);

            var bill = new BillModel(new [] {
                new LineItem("Cheerios", 10m, 12m)
            });
            var price = billCalculator.GetFinalAmount(bill, null);

            Assert.AreEqual(100, price);
        }

        [Test]
        public void GetPrice_OneProductWithNotFittedCoupon_ShouldReturnNormalPrice()
        {
            var mockBulkDiscountService = new Mock<IBulkDiscountService>();
            mockBulkDiscountService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);

            var billCalculator = new BillCalculator(mockBulkDiscountService.Object);

            var bill = new BillModel(new [] {
                new LineItem("Chocolate", 25m, 4m)
            });
            var coupon = new Coupon(110, 10);
            var price = billCalculator.GetFinalAmount(bill, new [] { coupon });

            Assert.AreEqual(100, price);
        }

        [Test]
        public void GetPrice_OneProductWithFittedCoupon_ShouldReturnDiscountedPrice()
        {
            var mockBulkDiscountService = new Mock<IBulkDiscountService>();
            mockBulkDiscountService
                .Setup(s => s.GetBulkDiscount(It.IsAny<string>()))
                .Returns(null as BulkDiscount);

            var billCalculator = new BillCalculator(mockBulkDiscountService.Object);

            var bill = new BillModel(new [] {
                new LineItem("Chocolate", 25m, 4m)
            });
            var coupon = new Coupon(100, 10);
            var price = billCalculator.GetFinalAmount(bill, new [] { coupon });

            Assert.AreEqual(90, price);
        }
    }
}