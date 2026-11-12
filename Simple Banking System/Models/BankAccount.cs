namespace Simple_Banking_System.Models
{
    public class BankAccount
    {
        #region -- Field --
        protected int _testValue = 100;

        #endregion


        #region -- Properties --
        public int AccountNumber { get; private set; } = 0;
        public string OwnerName { get; private set; } = "";
        public decimal Balance { get; private set; } = 0m;
        #endregion

        #region -- Constructors --
        public BankAccount(int accountnumber, string ownername)
        {
            this.AccountNumber = accountnumber;
            this.OwnerName = ownername;
        }
        #endregion

        #region -- Methods --
        public bool Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                return false;
            }

            Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if(amount <= 0)
            {
                return false;
            }

            if(Balance >= amount)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        #endregion
    }
}
