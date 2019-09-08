using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using EcommerceAPI.BAL.Factory;
using EcommerceAPI.BAL.Interfaces;
namespace EcommerceAPI.App_Start
{
    public class AutofacWebapiConfig
    {


        public static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CategoryManagementServiceFactory>().As<ICategoryManagementServiceFactory>().InstancePerRequest();
            builder.RegisterType<UserManagementServiceFactory>().As<IUserManagementServiceFactory>().InstancePerRequest();
            builder.RegisterType<YPProductManagementServiceFactory>().As<IYPProductManagementServiceFactory>().InstancePerRequest();

            container = builder.Build();
            return container;
        }
    }

}
