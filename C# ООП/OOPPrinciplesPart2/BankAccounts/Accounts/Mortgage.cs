namespace BankAccounts.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class Mortgage : BasicAccount, IDepositable
    {
        Mortgage(Customers customer, decimal balance, decimal interestRate)
            :base(customer, balance, interestRate) { }

        public void DepositM(decimal money)
        {
            base.Balance += money;
        }

        public override decimal InterestAmount(int months)
        {
            if (base.Customer == Customers.Individual && months > 6)
            {
                return ((base.InterestRate / 100) * base.Balance) * (months - 3);
            }
            else if (base.Customer == Customers.Company && months > 12)
            {
                return ((base.InterestRate / 100) * base.Balance * (months - 2))/2;
            }
            else
            {
                return 0;
            }
        }
    }
}
