using System.Threading.Tasks;
using GmailClient.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace GmailClient.Identity
{
    /// <summary>
    /// Custom user manager implementation for ASP.NET Identity
    /// </summary>
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="store">User store implementation</param>
        public CustomUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return Task<ApplicationUser>.Factory.StartNew(() => Store.FindByNameAsync(userName).Result);
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="context">Context</param>
        /// <returns></returns>
        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            return new CustomUserManager(new CustomUserStore());
        }
    }
}