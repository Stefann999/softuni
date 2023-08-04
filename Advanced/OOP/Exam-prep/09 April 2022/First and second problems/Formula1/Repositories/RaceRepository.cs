using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            races = new();
        }

        public IReadOnlyCollection<IRace> Models => this.races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string raceName) => races.FirstOrDefault(x => x.RaceName == raceName);

        public bool Remove(IRace model) => races.Remove(model);
    }
}
