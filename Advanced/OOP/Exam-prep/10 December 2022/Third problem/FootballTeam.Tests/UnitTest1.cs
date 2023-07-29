using NUnit.Framework;
using System.Xml.Linq;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InvalidTeamName()
        {
            FootballTeam team;

            Assert.Throws<ArgumentException>(() => team = new FootballTeam("", 15));
        }

        [Test]
        public void InvalidTeamCapacity()
        {
            FootballTeam team;

            Assert.Throws<ArgumentException>(() => team = new FootballTeam("Barcelona", 14));
        }

        [Test]
        public void TeamIsCreatedProperly()
        {
            FootballTeam footballTeam = new FootballTeam("Real Madrid", 33);

            List<FootballPlayer> footballPlayers = new List<FootballPlayer>();

            Assert.AreEqual("Real Madrid", footballTeam.Name);
            Assert.AreEqual(33, footballTeam.Capacity);
            Assert.AreEqual(footballPlayers, footballTeam.Players);
        }

        [Test]
        public void AddNewPlayerAdds()
        {
            FootballTeam footballTeam = new FootballTeam("Real Madrid", 33);
            FootballPlayer player = new FootballPlayer("Ivan", 7, "Forward");

            string expectedOutput = "Added player Ivan in position Forward with number 7";
            string actualOutput = footballTeam.AddNewPlayer(player);

            Assert.AreEqual(expectedOutput, actualOutput);
            Assert.AreEqual(1, footballTeam.Players.Count);
        }

        [Test]
        public void AddNewPlayerThrowsException()
        {
            FootballTeam footballTeam = new FootballTeam("Real Madrid", 15);
            FootballPlayer player1 = new FootballPlayer("Ivan", 7, "Forward");
            FootballPlayer player2 = new FootballPlayer("Ivans", 1, "Forward");
            FootballPlayer player3 = new FootballPlayer("Ivan12", 2, "Forward");
            FootballPlayer player4 = new FootballPlayer("Ivan2", 3, "Forward");
            FootballPlayer player5 = new FootballPlayer("Ivan2q", 4, "Forward");
            FootballPlayer player6 = new FootballPlayer("Ivasadn", 5, "Forward");
            FootballPlayer player7 = new FootballPlayer("Iva123n", 6, "Forward");
            FootballPlayer player8 = new FootballPlayer("Ivsadan", 12, "Forward");
            FootballPlayer player9 = new FootballPlayer("Ivaasdn", 11, "Forward");
            FootballPlayer player10 = new FootballPlayer("Ivan", 8, "Forward");
            FootballPlayer player11 = new FootballPlayer("Iv123an", 9, "Forward");
            FootballPlayer player12 = new FootballPlayer("Ivdasan", 10, "Forward");
            FootballPlayer player13 = new FootballPlayer("Ivdasan", 12, "Forward");
            FootballPlayer player14 = new FootballPlayer("Iv123an", 13, "Forward");
            FootballPlayer player15 = new FootballPlayer("Iva123n", 14, "Forward");
            FootballPlayer player16 = new FootballPlayer("Iv123an", 15, "Forward");

            footballTeam.AddNewPlayer(player1);
            footballTeam.AddNewPlayer(player2);
            footballTeam.AddNewPlayer(player3);
            footballTeam.AddNewPlayer(player4);
            footballTeam.AddNewPlayer(player5);
            footballTeam.AddNewPlayer(player6);
            footballTeam.AddNewPlayer(player7);
            footballTeam.AddNewPlayer(player8);
            footballTeam.AddNewPlayer(player9);
            footballTeam.AddNewPlayer(player10);
            footballTeam.AddNewPlayer(player11);
            footballTeam.AddNewPlayer(player12);
            footballTeam.AddNewPlayer(player13);
            footballTeam.AddNewPlayer(player14);
            footballTeam.AddNewPlayer(player15);

            string expectedOutput = "No more positions available!";
            string actualOutput = footballTeam.AddNewPlayer(player16);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void PickPlayerWorksProperly()
        {
            FootballTeam footballTeam = new FootballTeam("Real Madrid", 15);
            FootballPlayer player = new FootballPlayer("Ivan", 7, "Forward");

            footballTeam.AddNewPlayer(player);

            Assert.AreEqual(player, footballTeam.PickPlayer("Ivan"));
        }

        [Test]
        public void PlayerScoreWorksProperly()
        {
            FootballTeam footballTeam = new FootballTeam("Real Madrid", 15);
            FootballPlayer player = new FootballPlayer("Ivan", 7, "Forward");

            footballTeam.AddNewPlayer(player);

            string expectedOutput = "Ivan scored and now has 1 for this season!";
            string actualOutput = footballTeam.PlayerScore(7);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}