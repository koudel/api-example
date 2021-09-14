using Autofac;
using Product.Service.Application.UseCases.Command.Update;
using Product.Service.Domain.Repository;

namespace Product.Service.Application.AutofacModules
{
    /// <summary>
    /// Dependency injection setup of the application layer
    /// </summary>
    public class ApplicationModule : Module
    {
        /// <summary>
        /// Load the container builder with the dependency injection for the application
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UpdateProductDescriptionCommandHandler(
                c.Resolve<IMockRepository>())).As<UpdateProductDescriptionCommandHandler>().SingleInstance();
        }
    }
}