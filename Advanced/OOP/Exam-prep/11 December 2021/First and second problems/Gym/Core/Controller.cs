using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipmentRepo;
        private readonly List<IGym> gyms;

        public Controller()
        {
            equipmentRepo = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else { throw new InvalidOperationException("Invalid equipmentRepo type."); }
            equipmentRepo.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = equipmentRepo.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            equipmentRepo.Remove(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)//check this method
        {
            IAthlete athlete;
            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            if (athleteType == nameof(Boxer))
            {
                IGym targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
                if (targetGym == null || targetGym.GetType().Name != nameof(BoxingGym))
                {
                    return "The gym is not appropriate.";
                }
                targetGym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
            else
            {
                IGym targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
                if (targetGym == null || targetGym.GetType().Name != nameof(WeightliftingGym))
                {
                    return "The gym is not appropriate.";
                }
                targetGym.AddAthlete(athlete);
                return $"Successfully added {athleteType} to {gymName}.";
            }
        }

        public string TrainAthletes(string gymName)
        {
            IGym targetGym = gyms.FirstOrDefault(x => x.Name == gymName);
            int cnt = 0;

            foreach (var athlete in targetGym.Athletes)
            {
                athlete.Exercise();
                cnt++;
            }
            return $"Exercise athletes: {cnt}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym targerGym = gyms.FirstOrDefault(x => x.Name == gymName);
            double sum = targerGym.Equipment.Sum(x => x.Weight);
            return $"The total weight of the equipment in the gym {gymName} is {sum:f2} grams.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
