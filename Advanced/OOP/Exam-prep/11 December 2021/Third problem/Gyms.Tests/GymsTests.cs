using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GymIsCreatedProperly()
        {
            Gym gym = new Gym("asd", 5);
            Assert.AreEqual("asd", gym.Name);
            Assert.AreEqual(5, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void NameException()
        {
            Gym gym;
            Assert.Throws< ArgumentNullException > (() => gym = new Gym(null, 5), "Invalid gym name.");
        }

        [Test]
        public void CapacityException()
        {
            Gym gym;
            Assert.Throws<ArgumentException>(() => gym = new Gym("asd", -1), "Invalid gym capacity.");
        }

        [Test]
        public void AddAtheleteWorksProperly()
        {
            Gym gym = new Gym("asd", 5);
            Athlete athlete = new Athlete("ssss");

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAtheleteCountException()
        {
            Gym gym = new Gym("asd", 0);
            Athlete athlete = new Athlete("ssss");

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete), "The gym is full.");
        }

        [Test]
        public void RemoveAthleteWorksProperly()
        {
            Gym gym = new Gym("asd", 5);
            Athlete athlete = new Athlete("ssss");

            gym.AddAthlete(athlete);
            int expectedCntBefore = 1;
            int actualCntBefore = gym.Count;

            gym.RemoveAthlete("ssss");
            int expectedCntAfter = 0;
            int actualCntAfter = gym.Count;
            Assert.AreEqual(expectedCntBefore, actualCntBefore);
            Assert.AreEqual(expectedCntAfter, actualCntAfter);
        }

        [Test]
        public void RemoveAthleteCountException()
        {
            Gym gym = new Gym("asd", 5);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("eee"), "The athlete eee doesn't exist.");
        }
 
        [Test]
        public void InjureAthleteWorksProperly()
        {
            Gym gym = new Gym("asd", 5);
            Athlete athlete = new Athlete("ssss");

            gym.AddAthlete(athlete);
            
            Assert.AreEqual(athlete, gym.InjureAthlete("ssss"));
        }

        [Test]
        public void InjureAthleteNameException()
        {
            Gym gym = new Gym("asd", 5);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("www"), "The athlete www doesn't exist.");
        }

        [Test]
        public void ReportWorksproperly()
        {
            Gym gym = new Gym("asd", 5);
            Athlete athlete = new Athlete("ssss");

            gym.AddAthlete(athlete);

            string actualOutput = "Active athletes at asd: ssss";
            string expectedOutput = gym.Report();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
