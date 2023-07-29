using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;

        public RobotRepository()
        {
            robots = new();
        }
        public void AddNew(IRobot robot) => robots.Add(robot);

        public IRobot FindByStandard(int interfaceStandard) => this.robots.FirstOrDefault(x => x.InterfaceStandards.Any(y => y == interfaceStandard));

        public IReadOnlyCollection<IRobot> Models() => this.robots.AsReadOnly();

        public bool RemoveByName(string typeName) => robots.Remove(robots.FirstOrDefault(x => x.GetType().Name == typeName));
    }
}
