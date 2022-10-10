using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class BankAccount
    {
        public string Number { get; }

        public string Owner { get; }

        private readonly List<Transaction> _allTransactions = new List<Transaction>();

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions) balance += item.Amount;

                return balance;
            }
        }

        // constructor
        public BankAccount(string name, decimal initialDeposit)
        {
            Owner = name;

            var bankNumberGenerator = BankNumberGenerator.GetInstance();

            Number = bankNumberGenerator.GetNextBankNumber();

            MakeDeposit(initialDeposit, DateTime.Now, "Initial deposite");
        }


        // methods
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount),
                    "Amount to small. Amount of deposit should be more then '0'.");

            var currentTransaction = new Transaction(amount, date, note);
            _allTransactions.Add(currentTransaction);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
            if (Balance - amount <= 0)
                throw new InvalidOperationException(
                    "There are not enough funds in the account. Choose a smaller amount or top up your account."
                );
            var currentTransaction = new Transaction(-amount, date, note);
            _allTransactions.Add(currentTransaction);
        }

        public string GetTransactionHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tTime\t\tAmount\tNote");
            foreach (var transaction in _allTransactions)
            {
                report.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Date.ToShortTimeString()}\t{transaction.Amount}\t{transaction.Notes}");
            }
            
            return report.ToString();
        }
    }
}