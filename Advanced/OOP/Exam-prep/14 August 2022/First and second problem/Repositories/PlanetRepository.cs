using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void AddItem(IPlanet model)
        {
           planets.Add(model);
        }

        public IPlanet FindByName(string name) => planets.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            if (planets.Any(x => x.GetType().Name == name))
            {
                var target = planets.FirstOrDefault(x => x.GetType().Name == name);
                planets.Remove(target);
                return true;
            }
            return false;
        }
    }
}
