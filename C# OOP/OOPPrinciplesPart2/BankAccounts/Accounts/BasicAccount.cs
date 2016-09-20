namespace BankAccounts.Accounts
{
    using System;
    using BankAccounts.Customers;

    public abstract class BasicAccount
    {
        private decimal balance;
        private decimal interestRate;

        public BasicAccount(Customers customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customers Customer { get; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                if (balance<0)
                {
                    throw new ArgumentException("Balance should be positive");
                }
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            private set
            {
                if (interestRate<0)
                {
                    throw new ArgumentException("Interest rate should be positive");
                }
                this.interestRate = value;
            }
        }

        public virtual decimal InterestAmount(int months)
        {
            return (decimal)(this.InterestRate * months);
        }
    }
}
