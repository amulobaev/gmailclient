using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GmailClient.Data;
using GmailClient.Model;
using Microsoft.AspNet.Identity;

namespace GmailClient.Models
{
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserLockoutStore<ApplicationUser, string>, IUserTwoFactorStore<ApplicationUser, string>
    {
        private UserRepository _repository = new UserRepository();

        public CustomUserStore()
        {
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(ApplicationUser user)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                _repository.Create(user);
            });
            return task;
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            Task<ApplicationUser> task = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                return _repository.Get(Guid.Parse(userId));
            });
            return task;
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            Task<ApplicationUser> task = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                return _repository.GetAll().FirstOrDefault(x => string.Equals(x.UserName, userName));
            });
            return task;
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                user.Password = passwordHash;
            });
            return task;
        }

        
        
        
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            Task<string> task = Task<string>.Factory.StartNew(() =>
            {
                return user.Password;
            });
            return task;
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }


        
        
        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            Task<int> task = Task<int>.Factory.StartNew(() =>
            {
                return 0;
            });
            return task;
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            Task<bool> task = Task<bool>.Factory.StartNew(() =>
            {
                return false;
            });
            return task;
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        
        
        
        
        
        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            Task<bool> task = Task<bool>.Factory.StartNew(() =>
            {
                return false;
            });
            return task;
        }

    }
}