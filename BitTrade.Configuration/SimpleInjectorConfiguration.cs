using BitTrade.BLL.Services;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using BitTrade.DAL.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BitTrade.Configuration
{
    public class SimpleInjectorConfiguration
    {
        public static void Register(HttpConfiguration configuration)
        {
            // Create the container as usual.
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Options.AllowOverridingRegistrations = true;

            // Register your types, for instance:
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TradeEntities, TradeEntities>(Lifestyle.Scoped);
            container.Register<IAccountService>(() => new AccountService(container.GetInstance<IUnitOfWork>(), container.GetInstance<ISecurityService>()), Lifestyle.Scoped);
            RegisterServices(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(configuration);
            container.Verify();

            // Here your usual Web API configuration stuff.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }

        // Automaticly Injection
        private static void RegisterServices(Container container)
        {
            var serviceTypes = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(t => t.GetTypes())
                    .Where(t => t.IsClass && t.Namespace == "BitTrade.BLL.Services");

            //var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            //var serviceTypes = assemblies
            //    .SelectMany(t => t.GetTypes())
            //    .Where(t => t.IsClass && t.Namespace == "BenivoNetwork.BLL.Services");


            foreach (var serviceType in serviceTypes)
            {
                var interfaceType = serviceType.GetInterface($"I{serviceType.Name}");

                if (interfaceType != null)
                {
                    container.Register(interfaceType, serviceType, Lifestyle.Scoped);
                }
            }
        }
    }
}


//container.Register<IUserService>(() => new UserService(container.GetInstance<IUnitOfWork>()), Lifestyle.Scoped);
//container.Register<IAccountService>(() => new AccountService(container.GetInstance<IUnitOfWork>(), container.GetInstance<SecurityService>()), Lifestyle.Scoped);
