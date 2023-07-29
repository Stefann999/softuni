using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> models;

        public SubjectRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<ISubject> Models => this.models.AsReadOnly();

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }
        public ISubject FindById(int id) => models.FirstOrDefault(x => x.Id == id);

        public ISubject FindByName(string name) => this.models.FirstOrDefault(y => y.Name == name);
    }
}
