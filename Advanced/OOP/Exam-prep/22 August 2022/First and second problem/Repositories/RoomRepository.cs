using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> roomRepository;

        public RoomRepository()
        {
            roomRepository = new();
        }

        public void AddNew(IRoom model)
        {
            roomRepository.Add(model);
        }

        public IReadOnlyCollection<IRoom> All() => this.roomRepository.AsReadOnly();

        public IRoom Select(string criteria) => this.roomRepository.FirstOrDefault(x => x.GetType().Name == criteria);
    }
}
