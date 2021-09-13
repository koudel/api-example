using System;
using System.IO;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace Product.Service.Main
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            BuildWebHost(args).Run();

            var host = Host.CreateDefaultBuilder()
                    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                        logging.AddConsole();
                    })
                    .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                    .Build();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
