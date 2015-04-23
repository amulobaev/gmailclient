using GmailClient.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace GmailClient
{
    public partial class Startup
    {
        private void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<CustomUserManager>(CustomUserManager.Create);
            app.CreatePerOwinContext<CustomSignInManager>(CustomSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}