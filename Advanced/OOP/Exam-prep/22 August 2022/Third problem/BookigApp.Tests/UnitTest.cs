using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HotelCreatedProperly()
        {
            Hotel hotel = new Hotel("asd", 5);
            List<Room> rooms = new List<Room>();
            List<Booking> bookigs = new List<Booking>();

            Assert.AreEqual("asd", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
            Assert.AreEqual(rooms, hotel.Rooms);
            Assert.AreEqual(bookigs, hotel.Bookings);
        }

        [Test]
        public void NameException()
        {
            Hotel hotel;
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(" ", 5));
        }

        [Test]
        public void CategoryException()
        {
            Hotel hotel;
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("asd", 7));
        }

        [Test]
        public void AddRoomsWorksProperly()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void BookRoomAdultException()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 4, 1000));
        }

        [Test]
        public void BookRoomChildrenException()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 4, 1000));
        }
        [Test]
        public void BookRoomDurationException()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 1, 0, 1000));
        }


        //        int bedsNeeded = adults + children;

        //            foreach (var room in this.Rooms.OrderBy(x => x.BedCapacity))
        //            {
        //                if (room.BedCapacity >= bedsNeeded)
        //                {
        //                    if (budget >= residenceDuration* room.PricePerNight)
        //        {
        //            var booking = new Booking(this.bookings.Count + 1, room, residenceDuration);
        //            this.bookings.Add(booking);
        //            this.turnover += residenceDuration * room.PricePerNight;
        //        }
        //    }
        //}

        [Test]
        public void BookRoomWorksProperly()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 3, 1000);

            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void BookRoomDoesntBookBudgetAndDuration()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 3, 1);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [Test]
        public void BookRoomDoesntBookCapacity()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 6, 3, 1);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }
        //            this.turnover += residenceDuration * room.PricePerNight;

        [Test]
        public void BookRoomAddsTurnover()
        {
            Hotel hotel = new Hotel("asd", 5);
            Room room = new Room(5, 5);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 3, 1000);

            Assert.AreEqual(15, hotel.Turnover);
        }
    }
}