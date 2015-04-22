using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GmailClient.Data.Entities;
using GmailClient.Model;

namespace GmailClient.Data
{
    public class AccountRepository
    {
        static AccountRepository()
        {
            Mapper.CreateMap<AccountEntity, Account>();
        }

        public IEnumerable<Account> GetAll()
        {
            using (MailContext context = new MailContext())
            {
                List<AccountEntity> enitites = context.Accounts.ToList();
                return Mapper.Map<List<AccountEntity>, List<Account>>(enitites);
            }
        }

        public Account Get(int id)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = context.Accounts.FirstOrDefault(x => x.Id == id);
                Account account = entity != null ? Mapper.Map<AccountEntity, Account>(entity) : null;
                return account;
            }
        }
    }
}
