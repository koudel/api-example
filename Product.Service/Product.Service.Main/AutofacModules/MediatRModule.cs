using Autofac;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using Product.Service.Application.UseCases.Command.Update;
using System.Reflection;

namespace Product.Service.Main.AutofacModules
{
    /// <summary>
    /// Autofac module to setup MediatR
    /// </summary>
    public class MediatRModule : Autofac.Module
    {
        /// <summary>
        /// Setup of MediatR in the autofac container
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // Register all commands, responses and event handlers from the Application assembly
            // by getting the assembly name from one class implemented there.
            // lower version of Mediatr needed for this older .NET CORE version
            builder.AddMediatR(typeof(UpdateProductDescriptionCommand).Assembly);

            builder.RegisterAssemblyTypes(typeof(UpdateProductDescriptionCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();
        }
    }
}