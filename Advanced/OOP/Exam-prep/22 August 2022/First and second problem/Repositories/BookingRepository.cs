using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookingRepository;

        public BookingRepository()
        {
            bookingRepository = new();
        }
        public void AddNew(IBooking model)
        {
            bookingRepository.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => this.bookingRepository.AsReadOnly();

        public IBooking Select(string criteria) => this.bookingRepository.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
    }
}
