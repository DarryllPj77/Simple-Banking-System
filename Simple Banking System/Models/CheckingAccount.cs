namespace Simple_Banking_System.Models
{
    public class CheckingAccount : BankAccount
    {
        #region
        public decimal OverdraftLimit { get; private set; }
        #endregion


        #region -- Methods --
        public CheckingAccount(int accountNumber, string ownerName, decimal overdraftLimit)
            : base(accountNumber, ownerName)
        {
            this.OverdraftLimit = overdraftLimit;
        }

        public override string GetAccountType()
        {
            return "Checking Account";
        }

        #endregion


    }
}
