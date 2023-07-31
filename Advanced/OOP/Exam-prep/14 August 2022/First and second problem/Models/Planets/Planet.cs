using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;


        private List<IMilitaryUnit> units;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get => militaryPower;
            private set
            {
                double enduranceLevelPower = this.units.Sum(x => x.EnduranceLevel);
                double destructionLevelPower = this.weapons.Sum(x => x.DestructionLevel);
                double rawPower = enduranceLevelPower + destructionLevelPower;

                if (units.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                {
                    rawPower += rawPower - rawPower * 0.7;
                }
                if (weapons.Any(x => x.GetType().Name == "NuclearWeapon"))//try else if
                {
                    rawPower += rawPower - rawPower * 0.55;
                }
                militaryPower = value;
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units;//try readonly

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons;//try readonly

        public void AddUnit(IMilitaryUnit unit)
        {
            units.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine("--Forces: ");
            if (units.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                sb.Append(string.Join(", ", units.GetType().Name));
            }

            sb.AppendLine("--Combat equipment: ");
            if (weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                sb.Append(string.Join(", ", weapons.GetType().Name));
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in units)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
