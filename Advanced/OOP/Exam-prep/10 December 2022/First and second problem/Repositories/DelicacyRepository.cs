using ChristmasPastryShop.Models.Delicacies.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories.Contracts
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => this.models;

        public void AddModel(IDelicacy model)
        {
            models.Add(model);
        }
    }
}
