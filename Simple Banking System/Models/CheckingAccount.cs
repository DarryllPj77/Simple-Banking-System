namespace Simple_Banking_System.Models
{
    public class CheckingAccount : BankAccount
    {
        #region
        public decimal OverdraftLimit { get; private set; }
        #endregion

        public CheckingAccount(int accountNumber, string ownerName, decimal overdraftLimit)
            : base(accountNumber, ownerName)
        {
            this.OverdraftLimit = overdraftLimit;
        }

    }
}
