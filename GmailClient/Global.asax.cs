﻿using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GmailClient.Data;
using Ninject;
using Ninject.Web.Common;

namespace GmailClient
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new MyModule());
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create and start migration manager
            IMigrationManager migrationManager =
                new MigrationManager(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            migrationManager.Start();
        }
    }
}