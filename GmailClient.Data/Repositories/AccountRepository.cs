using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GmailClient.Data.Entities;
using GmailClient.Model;

namespace GmailClient.Data
{
    /// <summary>
    /// IRepository implementation for mail accounts
    /// </summary>
    public class AccountRepository : IRepository<Account>
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static AccountRepository()
        {
            // Create mappings for Automapper
            Mapper.CreateMap<Account, AccountEntity>();
            Mapper.CreateMap<AccountEntity, Account>();
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAll()
        {
            using (MailContext context = new MailContext())
            {
                List<AccountEntity> enitites = context.Accounts.ToList();
                return Mapper.Map<List<AccountEntity>, List<Account>>(enitites);
            }
        }

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetById(Guid id)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = context.Accounts.FirstOrDefault(x => x.Id == id);
                Account account = entity != null ? Mapper.Map<AccountEntity, Account>(entity) : null;
                return account;
            }
        }

        /// <summary>
        /// Create account in repo
        /// </summary>
        /// <param name="model">Account model</param>
        public void Create(Account model)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = Mapper.Map<Account, AccountEntity>(model);
                context.Accounts.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="model">Account model</param>
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

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="model">Account model</param>
        public void Delete(Account model)
        {
            using (MailContext context = new MailContext())
            {
                AccountEntity entity = context.Accounts.FirstOrDefault(x => x.Id == model.Id);
                if (entity != null)
                {
                    context.Accounts.DeleteOnSubmit(entity);
                    context.SubmitChanges();
                }
            }
        }

    }
}