using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.cars;

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string model) => cars.FirstOrDefault(x => x.Model == model);

        public bool Remove(IFormulaOneCar model) => cars.Remove(model);
    }
}
