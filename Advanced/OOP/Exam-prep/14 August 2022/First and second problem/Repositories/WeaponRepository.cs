using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name) => weapons.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            if (weapons.Any(x => x.GetType().Name == name))
            {
                var target = weapons.FirstOrDefault(x => x.GetType().Name == name);
                weapons.Remove(target);
                return true;
            }
            return false;
        }
    }
}
