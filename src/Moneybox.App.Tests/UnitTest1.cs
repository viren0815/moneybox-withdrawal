using Moneybox.App.Features;
using System;
using Xunit;

namespace Moneybox.App.Tests
{
    public class UnitTest1
    {
        private TransferMoney transferMoney;

        public UnitTest1()
        {
            transferMoney = new TransferMoney(new MockAccountRepository(), new MockNotificationService());
        }

        [Fact]
        public void Check_Insufficient_Balance()
        {
            Assert.ThrowsAny<InvalidOperationException>(() => transferMoney.Execute(new Guid("2bdbc3cd-3f5c-4514-8d2c-cb0540e9681e"), new Guid("498bf306-c58a-4dea-94e3-bbbc699f3328"), 1500m));
        }

        [Fact]
        public void Check_Account_PayInLimitReached()
        {
            Assert.ThrowsAny<InvalidOperationException>(() => transferMoney.Execute(new Guid("2bdbc3cd-3f5c-4514-8d2c-cb0540e9681e"), new Guid("498bf306-c58a-4dea-94e3-bbbc699f3328"), 5000m));
        }
    }
}
