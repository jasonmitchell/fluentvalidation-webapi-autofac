using Autofac;
using Autofac.Features.ResolveAnything;
using Sample.Web.Infrastructure;

namespace Sample.Web
{
    public partial class Startup
    {
        private static IContainer ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AutofacWebModule>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            var container = builder.Build();
            return container;
        }
    }
}