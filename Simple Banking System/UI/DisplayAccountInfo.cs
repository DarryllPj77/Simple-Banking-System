using Simple_Banking_System.Models;
using Simple_Banking_System.Service;

namespace Simple_Banking_System.UI
{
    public class DisplayAccountInfo
    {
        public static string GetAccountInfo(BankAccount account)
        {
            return $"Account Number: {account.AccountNumber}\n" +
                   $"Account Owner: {account.OwnerName}\n" +
                   $"Balance: {account.Balance:F2}";
        }

        public static void DisplayAccountByNumber(BankService bankService, int accountNumber)
        {
            BankAccount? account = bankService.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                Console.WriteLine(GetAccountInfo(account));
            }
            else
            {
                Console.WriteLine($"Account {accountNumber} was not found");
                return;
            }
        }
    }
}
