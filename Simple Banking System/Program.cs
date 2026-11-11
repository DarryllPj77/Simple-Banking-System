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
            SavingsAccount account2 = new SavingsAccount(123456789, "Darryll Pajaganas", 3);
            decimal depositAmount = 5000m;
            decimal withdrawalAmount = 500m;

            bankservice.AddAccount(account2);
            account2.Deposit(depositAmount);
            Console.WriteLine($"Deposit Amount: {depositAmount}");
            Console.WriteLine(DisplayAccountInfo.GetAccountInfo(account2));
            account2.Withdraw(withdrawalAmount);
            Console.WriteLine($"Withdraw Amount: {withdrawalAmount}");
            Console.WriteLine(DisplayAccountInfo.GetAccountInfo(account2));
            Console.WriteLine($"Interest Rate: {account2.InterestRate}");

        }
         
    }
}
