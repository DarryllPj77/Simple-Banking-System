using Simple_Banking_System.Models;
using Simple_Banking_System.Service;
using Simple_Banking_System.UI;

namespace Simple_Banking_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entry Point");
            BankService bankservice = new BankService();
            // BankAccount account1 = new BankAccount(123456789,"Darryll Pajaganas");

            SavingsAccount account2 = new SavingsAccount(123456789, "Darryll Pajaganas", 3);

            #region -- Experiment --
            // Experiment : this will not work
            //BankAccount savingsAccount1 = new SavingsAccount(123456789, "Darryll Pajaganas", 0.03m);
            //BankAccount checkingAccount1 = new CheckingAccount(123456789, "Darryll Pajaganas", 5000.0m);
            #endregion

            BankAccount savingsAccount1 = new SavingsAccount(123456789, "Darryll Pajaganas", 0.03m);
            BankAccount checkingAccount1 = new CheckingAccount(32134356, "Celeine Pike", 5000.0m);

            bool savingsAdded = bankservice.AddAccount(savingsAccount1);
            bool checkingAdded = bankservice.AddAccount(checkingAccount1);

            decimal depositAmount = 5000m;
            decimal withdrawalAmount = 500m;

            //bankservice.AddAccount(account1);
            //bankservice.AddAccount(account2);

            //account1.Deposit(1000);
            //Console.WriteLine(DisplayAccountInfo.GetAccountInfo(account1));
            //account1.Withdraw(500);
            //Console.WriteLine();

            #region -- Scenario for SavingsAccount Object --
            // Scenario for SavingsAccount Object
            //account2.Deposit(depositAmount);
            //Console.WriteLine($"Deposit Amount: {depositAmount}");
            ////Console.WriteLine(account2.Deposit(1000));
            //Console.WriteLine(DisplayAccountInfo.GetAccountInfo(account2));
            //account2.Withdraw(withdrawalAmount);
            //Console.WriteLine($"Withdraw Amount: {withdrawalAmount}");
            //Console.WriteLine(DisplayAccountInfo.GetAccountInfo(account2));
            //Console.WriteLine($"Interest Rate: {account2.InterestRate}");
            #endregion

            // Scenario for SavingsAccount and CheckingAccount

            savingsAccount1.Deposit(depositAmount);
            //Console.WriteLine($"Deposit Amount: {depositAmount}");
            savingsAccount1.Withdraw(withdrawalAmount);
            //Console.WriteLine(DisplayAccountInfo.GetAccountInfo(savingsAccount1));

            //Console.WriteLine(savingsAccount1.OverdraftLimit);
            //checkingAccount1.Deposit(depositAmount);
            //Console.WriteLine($"Deposit Amount: {depositAmount}");
            //checkingAccount1.Withdraw(withdrawalAmount);
            //Console.WriteLine(DisplayAccountInfo.GetAccountInfo(checkingAccount1));


            //Console.WriteLine($"Savings account added: {savingsAdded}");
            //Console.WriteLine($"Checkings account added: {checkingAdded}");

            DisplayAccountInfo.DisplayAccountByNumber(bankservice, 123456789);
            DisplayAccountInfo.DisplayAccountByNumber(bankservice, 32134356);





        }

    }
}
