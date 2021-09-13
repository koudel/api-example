using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Product.Service.Application.AutofacModules;
using Product.Service.Main.AutofacModules;
using Product.Service.Main.V1.Controllers;
using Product.Service.Main.V1.Apis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using static Product.Service.Main.Helpers.CommonHelper;
using Product.Service.Domain.Repository;

namespace Product.Service.Main
{
    /// <summary>
    /// Application startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup constructor
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{env.EnvironmentName}.json"), optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        /// <summary>
        /// App configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Product.Service API",
                        Description = "Product.Service API (ASP.NET Core 2.0)",
                        Contact = new OpenApiContact()
                        {
                            Name = Configuration["ContactName"],
                            Url = new Uri(Configuration["ContactUrl"]),
                            Email = Configuration["ContactMail"],
                        },
                    });

                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    var filePath = Path.Combine(AppContext.BaseDirectory, $"{PlatformServices.Default.Application.ApplicationName}.xml");
                    c.IncludeXmlComments(filePath);

                    c.OperationFilter<RemoveVersionParameterFilter>();
                    c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
                });

            services.AddMvc();

            services.AddScoped(typeof(IMockRepository), typeof(MockRepository));

            var container = new ContainerBuilder();
            container.Populate(services);
            container.RegisterModule(new ApplicationModule());
            container.RegisterModule(new MediatRModule());
            container.RegisterModule(new RestApiModule());
            //container.RegisterType<ProductController>().As<IProductController>();
            //container.RegisterType<Mediator>().As<IMediator>();
            /*container.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });*/
            /*container.Register(c => new ProductController(
                    c.Resolve<IMediator>())).As<IProductController>().InstancePerDependency();*/

            

            return new AutofacServiceProvider(container.Build());
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMockRepository repo)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product.Service V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            repo.SetRepository();

            app.UseMvc();
        }
    }
}
