using System.Threading.Tasks;
using GmailClient.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace GmailClient.Models
{
    /// <summary>
    /// Custom user manager implementation for ASP.NET Identity
    /// </summary>
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return Task<ApplicationUser>.Factory.StartNew(() => Store.FindByNameAsync(userName).Result);
        }

        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            return new CustomUserManager(new CustomUserStore());
        }
    }
}