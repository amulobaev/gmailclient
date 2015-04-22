using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using AutoMapper;
using GmailClient.Data.Entities;
using GmailClient.Model;

namespace GmailClient.Data
{
    public class UserRepository
    {
        static UserRepository()
        {
            Mapper.CreateMap<ApplicationUser, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserName));
            Mapper.CreateMap<UserEntity, ApplicationUser>()
                .ConstructUsing(x => new ApplicationUser(x.Id.ToString(), x.User, x.Password));
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            using (MailContext context = new MailContext())
            {
                Table<UserEntity> entities = context.Users;
                return Mapper.Map<IEnumerable<UserEntity>, List<ApplicationUser>>(entities);
            }
        }

        public ApplicationUser Get(Guid id)
        {
            using (MailContext context = new MailContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(x => x.Id == id);
                return entity != null ? Mapper.Map<UserEntity, ApplicationUser>(entity) : null;
            }
        }

        public void Create(ApplicationUser user)
        {
            using (MailContext context = new MailContext())
            {
                UserEntity entity = Mapper.Map<ApplicationUser, UserEntity>(user);
                context.Users.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

    }
}