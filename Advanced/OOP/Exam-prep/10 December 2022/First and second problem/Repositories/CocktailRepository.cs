using ChristmasPastryShop.Models.Cocktails.Contracts;
using System.Collections.Generic;
using System.Drawing;

namespace ChristmasPastryShop.Repositories.Contracts
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models;

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => this.models;

        public void AddModel(ICocktail model)
        {
            models.Add(model);
        }
    }
}
