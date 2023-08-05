using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loans;

        public LoanRepository()
        {
            loans = new();
        }

        public IReadOnlyCollection<ILoan> Models => this.loans.AsReadOnly();

        public void AddModel(ILoan model) => this.loans.Add(model);

        public ILoan FirstModel(string name) => this.loans.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveModel(ILoan model) => this.loans.Remove(model);
    }
}
