using GmailClient.Data;
using GmailClient.Model;
using Ninject.Modules;

namespace GmailClient
{
    /// <summary>
    /// Ninject configuration module
    /// </summary>
    public class MyModule : NinjectModule
    {
        /// <summary>
        /// Set bindings
        /// </summary>
        public override void Load()
        {
            Bind<IRepository<Account>>().To<AccountRepository>();
            Bind<IRepository<ApplicationUser>>().To<UserRepository>();
            Bind<IAccountInfo>().To<AccountInfo>();
        }
    }
}