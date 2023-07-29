using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            IRobot robot;
            switch (typeName)
            {
                case nameof(DomesticAssistant): robot = new DomesticAssistant(model); robots.AddNew(robot); break;
                case nameof(IndustrialAssistant): robot = new IndustrialAssistant(model); robots.AddNew(robot); break;
            }
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);

            }
            ISupplement supplement;
            switch (typeName)
            {
                case nameof(SpecializedArm): supplement = new SpecializedArm(); supplements.AddNew(supplement); break;
                case nameof(LaserRadar): supplement = new LaserRadar(); supplements.AddNew(supplement); break;
            }
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(m => m.GetType().Name == supplementTypeName);
            int interfceValue = supplement.InterfaceStandard;
            var robotsWithoutId = robots.Models().Where(m => !m.InterfaceStandards.Contains(interfceValue)).FirstOrDefault(r => r.Model == model);
            if (robotsWithoutId == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            robotsWithoutId.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var robotsWithGivenId = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).ToList();

            if (robotsWithGivenId.Count() == 0)
            {

                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            robotsWithGivenId = robotsWithGivenId.OrderByDescending(r => r.BatteryLevel).ToList();
            int sum = robotsWithGivenId.Sum(r => r.BatteryLevel);
            if (sum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, $"{totalPowerNeeded - sum}");
            }
            else
            {
                int counter = 0;
                foreach (var robot in robotsWithGivenId)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {

                        robot.ExecuteService(totalPowerNeeded);
                        counter++;
                        break;
                    }

                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        counter++;
                    }

                }
                return string.Format(OutputMessages.PerformedSuccessfully, serviceName, $"{counter}");
            }
        }


        public string RobotRecovery(string model, int minutes)
        {
            var robotsForFeed = robots.Models().Where(r => r.Model == model && r.BatteryLevel < r.BatteryCapacity / 2).ToList();
            int count = 0;
            foreach (var item in robotsForFeed)
            {
                item.Eating(minutes);
                count++;
            }
            return string.Format(OutputMessages.RobotsFed, count);
        }



        public string Report()
        {
            var orderedRobots = robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var robot in orderedRobots)
            {
                sb.AppendLine(robot.ToString());

            }
            return sb.ToString().TrimEnd();
        }




    }
}
