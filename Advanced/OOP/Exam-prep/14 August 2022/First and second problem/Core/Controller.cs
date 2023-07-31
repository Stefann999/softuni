using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private List<IPlanet> planets;

        public Controller()
        {
            planets = new List<IPlanet>();
        }


        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IPlanet planet = planets.FirstOrDefault(x => x.Name == planetName);

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            IMilitaryUnit unit;

            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            planet.AddUnit(unit);
            planet.Spend(unit.Cost);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            IPlanet planet = planets.FirstOrDefault(x => x.Name == planetName);

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Army of {planetName}!");
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(OutputMessages.ExistingPlanet, name);
            }
            else
            {
                Planet planet = new Planet(name, budget);
                planets.Add(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT ***");
            foreach (var planet in planets)
            {
                sb.AppendLine(planet.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        { 
            var firstPlanet = planets.FirstOrDefault(x => x.Name == planetOne);
            var secondPlanet = planets.FirstOrDefault(x => x.Name == planetTwo);

            bool firstNuclear = false;
            bool secondNuclear = false;
            if (firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                firstNuclear = true;
            }
            if (secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                secondNuclear = true;
            }

            IPlanet winner;
            IPlanet loser;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstNuclear && secondNuclear) || (!firstNuclear && !secondNuclear))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }

                if (firstNuclear)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }

                winner.Spend(winner.Budget / 2);
                winner.Profit(loser.Budget / 2);
                winner.Profit(loser.Army.Sum(x => x.Cost));
                winner.Profit(loser.Weapons.Sum(x => x.Price));
                planets.Remove(loser);
                return $"{winner.Name} destructed {loser.Name}!";
            }
            else
            {
                if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }

                winner.Spend(winner.Budget / 2);
                winner.Profit(loser.Budget / 2);

                winner.Profit(loser.Army.Sum(x => x.Cost));;
                winner.Profit(loser.Weapons.Sum(x => x.Price));
                planets.Remove(loser);
                return $"{winner.Name} destructed {loser.Name}!";

            }
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Any(x => x.Name == planetName))
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            IPlanet planet = planets.FirstOrDefault(x => x.Name == planetName);

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }
            planet.Spend(1.25);

            return $"{planetName} has upgraded its forces!";
        }
    }
}