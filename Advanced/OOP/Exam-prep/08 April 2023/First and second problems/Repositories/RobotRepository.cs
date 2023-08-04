using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;

        public RobotRepository()
        {
            robots = new();
        }

        public void AddNew(IRobot model) => robots.Add(model);

        public IRobot FindByStandard(int interfaceStandard) => this.robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));

        public IReadOnlyCollection<IRobot> Models() => this.robots.AsReadOnly();

        public bool RemoveByName(string typeName) => this.robots.Remove(this.robots.FirstOrDefault(x => x.GetType().Name == typeName));
    }
}
