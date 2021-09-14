using Autofac;
using System.Linq;

namespace Product.Service.Main.AutofacModules
{
    /// <summary>
    /// Loads the DI container with RestAPI classes
    /// </summary>
    public class RestApiModule : Autofac.Module
    {
        /// <summary>
        /// Load all Rest Api Classes
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var allClasses = assembly.GetTypes()
                .Where(t => t.IsClass && t.Namespace == "Product.Service.Main.V1.Controllers");
            var allInterfaces = assembly.GetTypes()
                .Where(t => t.IsInterface && t.Namespace == "Product.Service.Main.V1.Controllers");

            foreach (var i in allInterfaces)
            {
                foreach (var c in allClasses)
                {
                    if (i.IsAssignableFrom(c))
                    {
                        builder.RegisterAssemblyTypes(c.Assembly).AsImplementedInterfaces().SingleInstance();
                    }
                }
            }
        }
    }
}