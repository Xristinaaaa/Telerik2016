namespace BankAccounts.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class Deposit : BasicAccount, IDepositable, IWithdrawable
    {
        Deposit(Customers customer, decimal balance, decimal interestRate)
            :base(customer, balance, interestRate) { }

        public void DepositM(decimal money)
        {
            base.Balance += money;
        }
        public void Withdraw(decimal money)
        {
            base.Balance -= money;
        }
        public override decimal InterestAmount(int months)
        {
            if (base.Balance<0 && base.Balance>=1000)
            {
                return ((base.InterestRate / 100) * base.Balance) * months;
            }
            else
            {
                return 0;
            }
        }
    }
}
