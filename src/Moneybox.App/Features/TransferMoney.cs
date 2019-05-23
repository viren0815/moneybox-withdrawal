using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class TransferMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;
        private WithdrawMoney withdrawMoney;

        public TransferMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
            withdrawMoney = new WithdrawMoney(accountRepository, notificationService);
        }

        public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            var to = this.accountRepository.GetAccountById(toAccountId);

            withdrawMoney.Execute(fromAccountId, amount);

            to.Pay(amount);

            if (to.CheckPayInLimit())
            {
                this.notificationService.NotifyApproachingPayInLimit(to.User.Email);
            }

            this.accountRepository.Update(to);
        }
    }
}
