using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ShopIsCreatedProperly()
        {
            Shop shop = new(1);

            Assert.AreEqual(1, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void CapacityThrowsException()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new(-1));
        }

        [Test]
        public void AddWorksProperly()
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 100);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddExistException()
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 100);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void AddFullException()
        {
            Shop shop = new(1);
            Smartphone smartphone = new("asd", 100);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void RemoveWorksProperyl()//try another
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 100);
            shop.Add(smartphone);
            shop.Remove("asd");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void RemoveNotExistException()
        {
            Shop shop = new(5);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("ssss"));
        }

        [Test]
        public void TestPhoneWorksProperly()
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 100);
            shop.Add(smartphone);
            shop.TestPhone("asd", 40);

            Assert.AreEqual(60, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneNullException()
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 100);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("asd", 5));
        }

        [Test]
        public void TestPhoneChargeException()
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 10);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("asd", 50));
        }

        [Test]
        public void ChargePhoneWorksProperly()
        {
            Shop shop = new(5);
            Smartphone smartphone = new("asd", 100);
            smartphone.CurrentBateryCharge = 30;
            shop.Add(smartphone);
            shop.ChargePhone("asd");

            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneNullException()
        {
            Shop shop = new(5);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("asd"));
        }
    }
}