using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new();
        }

        public void AddNew(ISupplement model) => supplements.Add(model);

        public ISupplement FindByStandard(int interfaceStandard) => this.supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);

        public IReadOnlyCollection<ISupplement> Models() => this.supplements.AsReadOnly();

        public bool RemoveByName(string typeName) => this.supplements.Remove(this.supplements.FirstOrDefault(x => x.GetType().Name == typeName));
    }
}
