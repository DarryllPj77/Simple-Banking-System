using Simple_Banking_System.Models;

namespace Simple_Banking_System.Service
{
    public class BankService
    {
        private List<BankAccount> _accounts = new List<BankAccount>();

        public bool AddAccount(BankAccount account)
        {
            BankAccount? existingAccount = GetAccountByNumber(account.AccountNumber);

            // Prevent duplicate account numbers
            if (existingAccount is not null)
            {
                return false;
            }

            _accounts.Add(account);
            return true;
        }

        public BankAccount? GetAccountByNumber(int accountNumber)
        {
            foreach (BankAccount account in _accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }

            return null;
        }

        
    }
}