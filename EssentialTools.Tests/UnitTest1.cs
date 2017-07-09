using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]//Класс, который содержит тесты
    public class UnitTest1
    {
        //создает экземпляр объекта, который мы собираемся тестировать: MinimumDiscountHelper
        private IDiscountHelper getTestObject()//Не все методы в классе модульных тестов должны быть юнит тестами
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]//отдельными юнит тестами являются методы
        public void Discount_Above_100()
        {
            // PART ARRANGE !!!
            IDiscountHelper target = getTestObject(); //getTestObject создает экземпляр объекта который собираемся тестировать:MinimumDiscountHelper
            decimal total = 200;
            // PART ACT!!! вызываем метод MinimumDiscountHelper.ApplyDiscount и присваиваем результат переменной discountedTotal
            var discountedTotal = target.ApplyDiscount(total);
            // PART ASSERT !!!
            Assert.AreEqual(total * 0.9M, discountedTotal);//метод Assert.AreEqual, для проверки, значения, которые мы получили от метода ApplyDiscount, составляет 90% от первоначальной общей стоимости
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            //ARRANGE
            IDiscountHelper target = getTestObject();
            //ACT
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);
            //ASSERT
            Assert.AreEqual(5,TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            //ARRANGE
            IDiscountHelper target = getTestObject();
            //ACT
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);
            //ASSERT
            Assert.AreEqual(5,discount5);
            Assert.AreEqual(0,discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]//утверждение, которое будет выполнено только в том случае, если модульный тест выбросит исключение типа, указанного параметром ExceptionType.Это аккуратный способ ловить исключения без необходимости возиться с блоками try...catch в юнит тесте.
        public void Discount_Negative_Total()
        {
            //ARRANGE
            IDiscountHelper target = getTestObject();
            //ACT
            target.ApplyDiscount(-1);
            //ASSERT
        }
    }
}
