using System.Web.Http.Validation;
using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation;
using FluentValidation.WebApi;

namespace Sample.Web.Infrastructure
{
    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(ThisAssembly);

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => t.Name.EndsWith("Validator"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<FluentValidationModelValidatorProvider>().As<ModelValidatorProvider>();

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            base.Load(builder);
        }
    }
}