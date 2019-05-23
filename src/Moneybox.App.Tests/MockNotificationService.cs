using Moneybox.App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moneybox.App.Tests
{
    public class MockNotificationService : INotificationService
    {
        public void NotifyApproachingPayInLimit(string emailAddress)
        {
           
        }

        public void NotifyFundsLow(string emailAddress)
        {
            
        }
    }
}
