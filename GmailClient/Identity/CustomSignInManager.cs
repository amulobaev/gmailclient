using GmailClient.Model;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace GmailClient.Identity
{
    /// <summary>
    /// Custom SignInManager implementation for ASP.NET Identity
    /// </summary>
    public class CustomSignInManager : SignInManager<ApplicationUser, string>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userManager">User manager implementation</param>
        /// <param name="authenticationManager">Authentication manager</param>
        public CustomSignInManager(CustomUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="context">Context</param>
        /// <returns></returns>
        public static CustomSignInManager Create(IdentityFactoryOptions<CustomSignInManager> options, IOwinContext context)
        {
            return new CustomSignInManager(context.GetUserManager<CustomUserManager>(), context.Authentication);
        }
    }
}