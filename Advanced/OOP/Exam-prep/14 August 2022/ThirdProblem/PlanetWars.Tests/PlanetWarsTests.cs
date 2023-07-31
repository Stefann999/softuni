using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void PlanetCreatedProperly()
            {
                Planet planet = new Planet("asd", 55);
                List<Weapon> weapons = new List<Weapon>();

                Assert.AreEqual("asd", planet.Name);
                Assert.AreEqual(55, planet.Budget);
                Assert.AreEqual(weapons, planet.Weapons);
            }

            [Test]
            public void NameException()
            {
                Planet planet;
                Assert.Throws< ArgumentException>(() => planet = new Planet(null, 55), "Invalid planet Name");
            }

            [Test]
            public void BudgetException()
            {
                Planet planet;
                Assert.Throws<ArgumentException>(() => planet = new Planet("asd", -1), "Budget cannot drop below Zero!");
            }
           
            [Test]
            public void PowerIsCorrect()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);

                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitWorksProperly()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);
                planet.Profit(1);

                Assert.AreEqual(56, planet.Budget);
            }

            [Test]
            public void SpedFundsWorksProperly()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);

                planet.SpendFunds(1);

                Assert.AreEqual(54, planet.Budget);
            }

            [Test]
            public void SpendFundsThrowsException()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>  planet.SpendFunds(111), $"Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponWorksProperly()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void AddWeaponThrowsException()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            public void RemoveWeaponWorksProperly()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);
                int cntBefore = planet.Weapons.Count;
                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(cntBefore - 1, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeWeaponWorksProperly()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(2, weapon.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponThrowsException()
            {
                Planet planet = new Planet("asd", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                
                Assert.Throws<InvalidOperationException>(() =>  planet.UpgradeWeapon("sdadassda"), $"sdadassda does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void DestructOpponentWorksProperly()
            {
                Planet planet = new Planet("asd", 55);
                Planet planet2 = new Planet("ssss", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                Weapon weapon2 = new Weapon("qqqq", 1, 22);
                Weapon weapon3 = new Weapon("eeee", 1, 55);
                planet.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);
                planet2.AddWeapon(weapon3);
                string expectedResult = "asd is destructed!";
                string actualResult = planet2.DestructOpponent(planet);

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void DestructOpponentThrowsException()
            {
                Planet planet = new Planet("asd", 55);
                Planet planet2 = new Planet("ssss", 55);
                Weapon weapon = new Weapon("sss", 1, 1);
                Weapon weapon2 = new Weapon("qqqq", 1, 22);
                Weapon weapon3 = new Weapon("eeee", 1, 55);
                planet.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);
                planet2.AddWeapon(weapon3);

                Assert.Throws<InvalidOperationException>(() =>  planet.DestructOpponent(planet2), "ssss is too strong to declare war to!");
            }
        }
    }
}
