using System;


namespace MyBank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("Roman Kostiuk", 10000) ;

            Console.WriteLine($"Account {account.Number}  was created for {account.Owner} with balance {account.Balance}");
            
            account.MakeDeposit(150, DateTime.Now, "Saved money from birthday party");
            account.MakeWithdrawal(450, DateTime.Now, "My wife present");
            
            // Bad usage of method which gives us exception
            // account.MakeWithdrawal(30000, DateTime.Now, "bad deposit");

            Console.WriteLine(account.GetTransactionHistory());

        }
    }
}