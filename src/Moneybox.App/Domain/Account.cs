using System;

namespace Moneybox.App
{
    public class Account
    {
        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; private set; }

        public decimal Withdrawn { get; private set; }

        public decimal PaidIn { get; private set; }

        public void Pay(decimal amount)
        {
            if (amount > PayInLimit)
            {
                throw new InvalidOperationException("Account pay in limit reached");
            }
            this.PaidIn = this.PaidIn + amount;
            this.Balance = this.Balance + amount;
        }

        public void Withdrawal(decimal amount)
        {
            if (this.Balance - amount < 0m)
            {
                throw new InvalidOperationException("Insufficient funds to make transfer");
            }

            this.Withdrawn = this.Withdrawn - amount;
            this.Balance = this.Balance - amount;
        }

        public bool CheckPayInLimit()
        {
            if (PayInLimit - this.PaidIn < 500m)
            {
                return true;
            }
            return false;
        }

        public bool CheckLowFund()
        {
            if (Balance < 500m)
            {
                return true;
            }
            return false;
        }
    }
}
