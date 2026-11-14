namespace Simple_Banking_System.Models
{
    public class SavingsAccount : BankAccount // inherit from BankAccount
    {
        #region -- Property --
        public decimal InterestRate { get; private set; } = 0m;
        #endregion

        #region -- Constructor --
        // Inheriting the constructor of the parent class
        public SavingsAccount(int accountNumber, string ownerName, decimal interestRate) 
            : base(accountNumber, ownerName)
        {
            this.InterestRate = interestRate;
        }
        #endregion

        #region -- Methods --
        public void TestAccess()
        {
            Console.WriteLine(_testValue);
        }

        public override string GetAccountType()
        {
            return "Savings Account";
        }




        #endregion
    }
}
