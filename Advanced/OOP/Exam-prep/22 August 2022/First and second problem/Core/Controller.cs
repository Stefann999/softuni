﻿using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(x => x.FullName == hotelName && x.Category == category))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            else
            {
                Hotel hotel = new(hotelName, category);
                hotels.AddNew(hotel);
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (this.hotels.All().FirstOrDefault(x => x.Category == category) == default)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var orderedHotels =
                this.hotels.All().Where(x => x.Category == category).OrderBy(x => x.Turnover).ThenBy(x => x.FullName);


            foreach (var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .Where(y => y.BedCapacity >= adults + children)
                    .OrderBy(z => z.BedCapacity).FirstOrDefault();

                if (selectedRoom != null)
                {
                    int bookingNumber = this.hotels.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine($"{booking.BookingSummary()}");
                    sb.AppendLine();
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                throw new ArgumentException(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return String.Format(OutputMessages.RoomTypeNotCreated);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            else if (hotels.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room;
            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IHotel hotel = hotels.Select(hotelName);

            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
