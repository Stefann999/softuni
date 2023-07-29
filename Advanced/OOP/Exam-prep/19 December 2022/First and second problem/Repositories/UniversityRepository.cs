using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;

        public UniversityRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IUniversity> Models => this.models.AsReadOnly();

        public void AddModel(IUniversity model)
        {
            this.models.Add(model);
        }

        public IUniversity FindById(int id) => this.models.FirstOrDefault(x => x.Id == id);

        public IUniversity FindByName(string name) => this.models.FirstOrDefault(y => y.Name == name);
    }
}
