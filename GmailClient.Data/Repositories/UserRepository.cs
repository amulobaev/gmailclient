using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using AutoMapper;
using GmailClient.Data.Entities;
using GmailClient.Model;

namespace GmailClient.Data
{
    /// <summary>
    /// IRepository implementation for ApplicationUser model
    /// </summary>
    public class UserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static UserRepository()
        {
            // Create mappings
            Mapper.CreateMap<ApplicationUser, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserName));
            Mapper.CreateMap<UserEntity, ApplicationUser>()
                .ConstructUsing(x => new ApplicationUser(x.Id.ToString(), x.User, x.Password));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationUser> GetAll()
        {
            using (MailContext context = new MailContext())
            {
                Table<UserEntity> entities = context.Users;
                return Mapper.Map<IEnumerable<UserEntity>, List<ApplicationUser>>(entities);
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns></returns>
        public ApplicationUser GetById(Guid id)
        {
            using (MailContext context = new MailContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(x => x.Id == id);
                return entity != null ? Mapper.Map<UserEntity, ApplicationUser>(entity) : null;
            }
        }

        /// <summary>
        /// Create user in repo
        /// </summary>
        /// <param name="user"></param>
        public void Create(ApplicationUser user)
        {
            using (MailContext context = new MailContext())
            {
                UserEntity entity = Mapper.Map<ApplicationUser, UserEntity>(user);
                context.Users.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        /// <summary>
        /// Update user entity in repo
        /// </summary>
        /// <param name="model">User model</param>
        public void Update(ApplicationUser model)
        {
            using (MailContext context = new MailContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(x => x.Id == Guid.Parse(model.Id));
                if (entity != null)
                {
                    Mapper.Map(model, entity);
                    context.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// Delete user entity in repo
        /// </summary>
        /// <param name="model"></param>
        public void Delete(ApplicationUser model)
        {
            using (MailContext context = new MailContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(x => x.Id == Guid.Parse(model.Id));
                if (entity != null)
                {
                    context.Users.DeleteOnSubmit(entity);
                    context.SubmitChanges();
                }
            }
        }
    }
}