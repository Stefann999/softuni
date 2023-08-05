using BankLoan.Models.Contracts;
using System.Collections.Generic;
using System;
using BankLoan.Utilities.Messages;
using System.Linq;
using System.Text;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public int Capacity {get; private set;}

        public IReadOnlyCollection<ILoan> Loans => this.loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => this.clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (this.clients.Count == Capacity)
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
            this.clients.Add(Client);
        }

        public void AddLoan(ILoan loan) => this.loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            sb.Append($"Clients: ");
            if (this.clients.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                List<string> names = new List<string>();
                foreach (var client in this.clients)
                {
                    names.Add(client.Name);
                }

                sb.Append(string.Join(", ", names));
                sb.AppendLine();
            }
            sb.AppendLine($"Loans: {this.loans.Count}, Sum of Rates: {this.loans.Sum(x => x.InterestRate)}");
            return sb.ToString().TrimEnd();
        }

        public void RemoveClient(IClient Client) => this.clients.Remove(Client);

        public double SumRates() => this.loans.Sum(x => x.InterestRate);
    }
}
