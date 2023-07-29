using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new();
        }

        public IReadOnlyCollection<IStudent> Models => this.models;

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id) => this.models.FirstOrDefault(x => x.Id == id);

        public IStudent FindByName(string name) => this.models.FirstOrDefault(x => x.FirstName == name.Split(' ')[0] && x.LastName == name.Split(' ')[1]);
    }
}
