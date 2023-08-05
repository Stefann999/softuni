using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {
            loans = new();
            banks = new();
        }

        public string AddBank(string bankTypeName, string name)
        {
            IBank bank;
            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }
            else
            {
                throw new ArgumentException("Invalid bank type.");
            }
            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }
        public string AddLoan(string loanTypeName)
        {
            ILoan loan;
            if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }
            else if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else
            {
                throw new ArgumentException("Invalid loan type.");
            }
            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);
            if (loan == null)
            {
                throw new ArgumentException($"Loan of type {loanTypeName} is missing.");
            }
            IBank bank = banks.FirstModel(bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);
            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client;
            if (clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }
            else if (clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else if (true)
            {
                throw new ArgumentException($"Invalid client type.");
            }
            IBank bank = banks.FirstModel(bankName);
            if (clientTypeName == nameof(Adult) && bank.GetType().Name != nameof(CentralBank))
            {
                return "Unsuitable bank.";
            }
            else if (clientTypeName == nameof(Student) && bank.GetType().Name != nameof(BranchBank))
            {
                return "Unsuitable bank.";
            }

            bank.AddClient(client);
            return $"{clientTypeName} successfully added to {bankName}.";
        }


        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);
            double incomeSum = bank.Clients.Sum(c => c.Income);
            double amountSum = bank.Loans.Sum(c => c.Amount);
            double totalSum = incomeSum + amountSum;
            return $"The funds of bank {bankName} are {totalSum:f2}.";
        }


        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
