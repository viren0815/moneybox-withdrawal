using Moneybox.App;
using Moneybox.App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moneybox.App.Tests
{
    public class MockAccountRepository : IAccountRepository
    {
        private List<Account> _accounts;

        public MockAccountRepository()
        {
            _accounts = new List<Account>()
            {
                new Account(){ Id = new Guid("2bdbc3cd-3f5c-4514-8d2c-cb0540e9681e"), User = new User(){ Id = new Guid(), Email = "user1@users.com", Name = "user1"}},
                new Account(){ Id = new Guid("498bf306-c58a-4dea-94e3-bbbc699f3328"), User = new User(){ Id = new Guid(), Email = "user2@users.com", Name = "user2"}}
            };
        }

        public Account GetAccountById(Guid accountId)
        {
            return _accounts.FirstOrDefault(a => a.Id == accountId);
        }        

        public void Update(Account account)
        {
           
        }
    }
}
