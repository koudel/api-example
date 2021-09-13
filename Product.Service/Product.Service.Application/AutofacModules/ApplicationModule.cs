using Autofac;
using Microsoft.Extensions.Logging;
using Product.Service.Application.UseCases.Command.Update;
using Product.Service.Domain.Repository;

namespace Product.Service.Application.AutofacModules
{
    /// <summary>
    /// Dependency injection setup of the application
    /// </summary>
    public class ApplicationModule : Module
    {
        /// <summary>
        /// Load the container builder with the dependency injection for the application
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ApplicationStartup(
                c.Resolve<ILogger<ApplicationStartup>>())).As<IApplicationStartup>().SingleInstance();

            builder.Register(c => new UpdateProductDescriptionCommandHandler(
                c.Resolve<IMockRepository>())).As<UpdateProductDescriptionCommandHandler>().SingleInstance();
        }
    }
}