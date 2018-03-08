using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServicesLibrary.Classes;
using ServicesLibrary.Interfaces;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;

namespace RTGClientv1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //TODO: Register types for DI here
            builder.RegisterType<ImageService>().As<IImageService>();
            builder.RegisterType<ImageAcquisition>().As<IImageAcquisition>();
            builder.RegisterType<ConnectionService>().As<IConnectionService>();
            builder.RegisterType<ConnectionAcquisition>().As<IConnectionAcquisition>();
            builder.RegisterType<LoginAcquisition>().As<ILoginAcquisition>();
            builder.RegisterType<LoginValidationService>().As<ILoginValidationService>();
            builder.RegisterType<AuditLogsAcquisition>().As<IAuditLogsAcquisition>();
            builder.RegisterType<AuditLogsService>().As<IAuditLogsService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
