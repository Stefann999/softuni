using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> banks;

        public BankRepository()
        {
            banks = new();
        }

        public IReadOnlyCollection<IBank> Models => this.banks.AsReadOnly();

        public void AddModel(IBank model) => this.banks.Add(model);

        public IBank FirstModel(string name) => this.banks.FirstOrDefault(x => x.Name == name);

        public bool RemoveModel(IBank model) => this.banks.Remove(model);
    }
}
