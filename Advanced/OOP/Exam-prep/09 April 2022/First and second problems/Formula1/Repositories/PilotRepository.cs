using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new();
        }
        public IReadOnlyCollection<IPilot> Models => this.pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string fullName) => pilots.FirstOrDefault(x => x.FullName == fullName);

        public bool Remove(IPilot model) => pilots.Remove(model);
    }
}
