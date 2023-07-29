using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SupplementIsCreatedProperly()
        {
            Factory factory = new Factory("SpaceX", 2);

            string expectedResult = "Supplement: SpecializedArm IS: 8";
            string actualResult = factory.ProduceSupplement("SpecializedArm", 8);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RobotIsCreatedProperly()
        {
            Factory factory = new("asd", 5);

            string expectedResult = "Produced --> Robot model: Fast-Robot IS: 5, Price: 3000.00";
            string actualResult = factory.ProduceRobot("Fast-Robot", 3000, 5);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FactoryIsCreatedProperly()
        {
            Factory factory = new("Asd", 5);
            List<Robot> expectedRobotList = new List<Robot>();
            List<Supplement> expectedSuppList = new List<Supplement>();

            Assert.AreEqual("Asd", factory.Name);
            Assert.AreEqual(5, factory.Capacity);
            Assert.AreEqual(expectedRobotList, factory.Robots);
            Assert.AreEqual(expectedSuppList, factory.Supplements);
        }

        [TestCase("Asd", 5000, 5)]
        [TestCase("qwer", 1111, 1)]
        public void ProduceRobotAddsProperly(string model, double price, int interfaceStandard)
        {
            Factory factory = new("asd", 5);

            int expectedCntBefore = 0;
            int actualCntBefore = factory.Robots.Count;

            factory.ProduceRobot(model, price, interfaceStandard);

            int expectedCntAfter = 1;
            int actualCntAfter = factory.Robots.Count;

            Assert.AreEqual(expectedCntBefore, actualCntBefore);
            Assert.AreEqual(expectedCntAfter, actualCntAfter);
        }

        [Test]
        public void ProduceRobotThrowsExceptionWhenFctoryIsFull()
        {
            Factory factory = new("asd", 1);

            factory.ProduceRobot("Asd", 5000, 5);
            factory.ProduceRobot("Asd", 5000, 5);
            string expectedOutput = "The factory is unable to produce more robots for this production day!";
            string actualOutput = factory.ProduceRobot("dsadsa", 1, 1);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void ProduceSupplement_CheckAdding()
        {
            Factory factory = new Factory("SpaceX", 10);

            int expectedCountBeforeProduce = 0;
            int actualCountBeforeProduce = factory.Supplements.Count;

            factory.ProduceSupplement("SpecializedArm", 8);

            int expectedCountAfterProduce = 1;
            int actualCountAfterProduce = factory.Supplements.Count;

            Assert.AreEqual(expectedCountBeforeProduce, actualCountBeforeProduce);
            Assert.AreEqual(expectedCountAfterProduce, actualCountAfterProduce);
        }

        [Test]
        public void UprageRobotReturnsTrue()
        {
            Factory factory = new("asd", 5);
            Robot robot = new("ssss", 5000, 5);
            Supplement supplement = new("eeee", 5);

            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UprageRobotReturnsFalseDiffStandards()
        {
            Factory factory = new("asd", 5);
            Robot robot = new("ssss", 5000, 5);
            Supplement supplement = new("eeee", 1);

            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UprageRobotReturnsFalseAlreadyUpgraded()
        {
            Factory factory = new Factory("SpaceX", 10);

            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceSupplement("SpecializedArm", 22);

            factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            var actualResult = factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void SellRobotWorksProperly()
        {
            Factory factory = new("asd", 5);

            Robot robot = new("asd", 111, 1);
            Robot robot2 = new("ssss", 222, 2);

            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);

            Assert.AreEqual (robot2, factory.SellRobot(222));
        }
    }
}