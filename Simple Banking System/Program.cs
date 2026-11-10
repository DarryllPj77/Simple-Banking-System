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
            BankAccount account1 = new BankAccount(123456789,"Darryll Pajaganas");

            bankservice.AddAccount(account1);

            account1.Deposit(1000);
            Console.WriteLine(DisplayAccountInfo.GetAccountInfo(account1));
            account1.Withdraw(500);
            Console.WriteLine();

           
        }
         
    }
}
