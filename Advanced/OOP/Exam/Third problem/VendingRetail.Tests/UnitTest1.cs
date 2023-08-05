using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CoffeeMatIsCreatedProperly()
        {
            CoffeeMat coffeeMat = new(1, 5);

            Type type = typeof(CoffeeMat);
            FieldInfo waterTankInfo = type.GetField("waterTankLevel", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo drinks = type.GetField("drinks", BindingFlags.NonPublic | BindingFlags.Instance);

            int actLevel = (int)waterTankInfo.GetValue(coffeeMat);
            Dictionary<string, double> actDrinks = (Dictionary<string, double>)drinks.GetValue(coffeeMat);
            Dictionary<string, double> asd = new Dictionary<string, double>();


            Assert.AreEqual(1, coffeeMat.WaterCapacity);
            Assert.AreEqual(5, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);
            Assert.AreEqual(0, actLevel);
            Assert.AreEqual(asd, actDrinks);
        }
        [Test]
        public void Income()
        {
            CoffeeMat coffeeMat = new(100, 5);

            double exBefore = 0;
            double accBefore = coffeeMat.Income;
            coffeeMat.AddDrink("asd", 5);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("asd");
            double exAfter = 5;
            double accAfter = coffeeMat.Income;
            
            Assert.AreEqual(exBefore, accBefore);
            Assert.AreEqual(exAfter, accAfter);
        }

        [Test]
        public void FillWaterTankWorksProperly()
        {
            CoffeeMat coffeeMat = new(5, 5);

            string expectedOutput = "Water tank is filled with 5ml";
            string actualOutput = coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FillWaterTankReturnsException()
        {
            CoffeeMat coffeeMat = new(5, 5);
            coffeeMat.FillWaterTank();

            string expectedOutput = "Water tank is already full!";
            string actualOutput = coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void AddDrinkReturnsTrue()
        {
            CoffeeMat coffeeMat = new(5, 5);

            Assert.IsTrue(coffeeMat.AddDrink("asd", 1));
            Assert.IsTrue(coffeeMat.AddDrink("eee", 3));
        }

        [Test]
        public void AddDrinkReturnsFalseButtons()
        {
            CoffeeMat coffeeMat = new(5, 1);
            coffeeMat.AddDrink("asd", 1);
            Assert.IsFalse(coffeeMat.AddDrink("eee", 5));
        }
        [Test]
        public void AddDrinkReturnsName()
        {
            CoffeeMat coffeeMat = new(5, 5);
            coffeeMat.AddDrink("asd", 1);

            Assert.IsFalse(coffeeMat.AddDrink("asd", 1));
        }

        [Test]
        public void BuyDrinkWorksProperly()
        {
            CoffeeMat coffeeMat = new(100, 5);

            coffeeMat.AddDrink("asd", 1);
            coffeeMat.FillWaterTank();
            string expectedOutput = "Your bill is 1.00$";
            string actualOutput = coffeeMat.BuyDrink("asd");

            Type type = coffeeMat.GetType();
            FieldInfo waterTankInfo = type.GetField("waterTankLevel", BindingFlags.NonPublic | BindingFlags.Instance);

            int actLevel = (int)waterTankInfo.GetValue(coffeeMat);

            Assert.AreEqual(expectedOutput, actualOutput);
            Assert.AreEqual(1, coffeeMat.Income);
            Assert.AreEqual(20, actLevel);
        }

        [Test]
        public void BuyDrinkReturnWater()
        {
            CoffeeMat coffeeMat = new(100, 5);
            coffeeMat.AddDrink("asd", 1);

            string expectedOutput = "CoffeeMat is out of water!";
            string actualOutput = coffeeMat.BuyDrink("asd");

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void BuyDrinkReturnName()
        {
            CoffeeMat coffeeMat = new(100, 5);
            coffeeMat.FillWaterTank();

            string expectedOutput = "asd is not available!";
            string actualOutput = coffeeMat.BuyDrink("asd");

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void CollectIncomeWorksProperly()
        {
            CoffeeMat coffeeMat = new(100, 5);
            coffeeMat.AddDrink("asd", 1);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("asd");

            Assert.AreEqual(1, coffeeMat.CollectIncome());
            Assert.AreEqual(0, coffeeMat.Income);
        }
    }
}