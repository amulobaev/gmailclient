using System;
using System.Linq;
using System.Threading.Tasks;
using GmailClient.Data;
using GmailClient.Model;
using Microsoft.AspNet.Identity;

namespace GmailClient.Identity
{
    /// <summary>
    /// User store custom implementation for ASP.NET Identity 
    /// </summary>
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>,
        IUserLockoutStore<ApplicationUser, string>, IUserTwoFactorStore<ApplicationUser, string>
    {
        private readonly UserRepository _repository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomUserStore()
        {
            // Create local users repository
            _repository = new UserRepository();
        }

        #region IUserStore implementation

        public void Dispose()
        {
        }

        public Task CreateAsync(ApplicationUser user)
        {
            return Task.Factory.StartNew(() => { _repository.Create(user); });
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
            return Task<ApplicationUser>.Factory.StartNew(() => _repository.GetById(Guid.Parse(userId)));
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Task<ApplicationUser>.Factory.StartNew(() =>
            {
                return _repository.GetAll().FirstOrDefault(x => string.Equals(x.UserName, userName));
            });
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            return Task.Factory.StartNew(() => { user.Password = passwordHash; });
        }

        #endregion IUserStore implementation

        #region IUserPasswordStore implementation

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task<string>.Factory.StartNew(() => user.Password);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        #endregion IUserPasswordStore implementation

        #region IUserLockoutStore implementation

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
            return Task<int>.Factory.StartNew(() => 0);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return Task<bool>.Factory.StartNew(() => false);
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        #endregion IUserLockoutStore implementation

        #region IUserTwoFactorStore implementation

        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return Task<bool>.Factory.StartNew(() => false);
        }

        #endregion IUserTwoFactorStore implementation

    }
}