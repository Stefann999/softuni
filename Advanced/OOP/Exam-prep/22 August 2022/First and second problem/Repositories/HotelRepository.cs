using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotelsRepository;

        public HotelRepository()
        {
            hotelsRepository = new();
        }

        public void AddNew(IHotel model)
        {
            hotelsRepository.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => this.hotelsRepository.AsReadOnly();

        public IHotel Select(string criteria) => this.hotelsRepository.FirstOrDefault(x => x.FullName == criteria);
    }
}
