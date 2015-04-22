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
    public class AccountRepository : IRepository<Account>
    {
        static AccountRepository()
        {
            Mapper.CreateMap<Account, AccountEntity>();
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

        public Account GetById(Guid id)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = context.Accounts.FirstOrDefault(x => x.Id == id);
                Account account = entity != null ? Mapper.Map<AccountEntity, Account>(entity) : null;
                return account;
            }
        }

        public void Create(Account model)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = Mapper.Map<Account, AccountEntity>(model);
                context.Accounts.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public void Update(Account model)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = context.Accounts.FirstOrDefault(x => x.Id == model.Id);
                if (entity != null)
                {
                    Mapper.Map(model, entity);
                    context.SubmitChanges();
                }
            }
        }

        public void Delete(Account model)
        {
            throw new NotImplementedException();
        }

    }
}