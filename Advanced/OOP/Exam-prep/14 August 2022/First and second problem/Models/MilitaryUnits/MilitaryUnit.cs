using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Runtime.Serialization;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel {get; private set; }

        public void IncreaseEndurance()
        {
            if (EnduranceLevel == 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
            else
            {
                EnduranceLevel++;
            }
        }
    }
}
