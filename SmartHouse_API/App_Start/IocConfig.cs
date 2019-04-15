using Autofac;
using Autofac.Integration.WebApi;
using SmartHouse_API.DAL;
using System.Reflection;
using System.Web.Http;

namespace SmartHouse_API.App_Start
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DbOperativeMethods>().As<IDbOperative>().InstancePerRequest();
            builder.RegisterType<DbContext>().AsSelf().InstancePerRequest();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}