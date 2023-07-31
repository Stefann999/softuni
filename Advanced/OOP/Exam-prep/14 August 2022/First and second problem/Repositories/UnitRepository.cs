using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.units.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name) => units.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            if (units.Any(x => x.GetType().Name == name))
            {
                var target = units.FirstOrDefault(x => x.GetType().Name == name);
                units.Remove(target);
                return true;
            }
            return false;
        }
    }
}
