using Simple_Banking_System.Models;
using Simple_Banking_System.Service;

namespace Simple_Banking_System.UI
{
    public class DisplayAccountInfo
    {
        public static string GetAccountInfo(BankAccount account)
        {
            return $"Account Number: {account.AccountNumber}\nAccount Owner: {account.OwnerName}\nBalance: {account.Balance:F2}";
        }

    }
}
