using System.Configuration;
using System.Reflection;
using System.Security.Policy;
using System.Web.Hosting;
using System.Windows;
using Autofac;
using Autofac.Integration.WebApi;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using HomeyDebugger.Api;
using HomeyDebugger.ViewModels;
using Microsoft.Owin.Hosting;

namespace HomeyDebugger
{
    class AppBootstrapper : AutofacBootstrapper<DebugViewModel>
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        private SimpleContainer _container = new SimpleContainer();

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<DebugViewModel>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
            EnforceNamespaceConvention = false;
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<DebugViewModel>();

            OwinWebApiConfig.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            WebApp.Start<OwinWebApiConfig>(ConfigurationManager.AppSettings["Address"]);
        }
    }
}
