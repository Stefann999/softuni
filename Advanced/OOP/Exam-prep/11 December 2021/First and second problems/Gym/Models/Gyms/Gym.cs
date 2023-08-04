using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipmentCollection;
        private List<IAthlete> athletesCollection;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipmentCollection = new List<IEquipment>();
            athletesCollection = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity {get; private set; }

        public double EquipmentWeight => equipmentCollection.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => this.equipmentCollection;

        public ICollection<IAthlete> Athletes => this.athletesCollection;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletesCollection.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            athletesCollection.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) => equipmentCollection.Add(equipment);

        public void Exercise()
        {
            foreach (var athlete in athletesCollection)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");//check here
            sb.Append("Athletes: ");
            if (athletesCollection.Count == 0)
            {
                sb.AppendLine("No atheletеs");
            }
            else
            {
                foreach (var athlete in athletesCollection)
                {
                    sb.Append(athlete.FullName);
                }
                sb.AppendLine();
            }
            sb.AppendLine($"Equipment total count: {equipmentCollection.Count}");
            sb.AppendLine($"Equipment total weight: {equipmentCollection.Sum(x => x.Weight):f2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => athletesCollection.Remove(athlete);
    }
}
