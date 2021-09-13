using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Product.Service.Application
{
    /// <summary>
    /// Application startup
    /// </summary>
    public class ApplicationStartup : Product.Service.Application.IApplicationStartup
    {
        private readonly ILogger<ApplicationStartup> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationStartup"/> class.
        /// </summary>
        /// <param name="logger"></param>
        public ApplicationStartup(ILogger<ApplicationStartup> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Start the application
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task RunAsync(CancellationToken token = default(System.Threading.CancellationToken))
        {
            _logger.LogInformation("Starting Application");
            await Task.CompletedTask;
        }

        /// <summary>
        /// Shutdown the application
        /// </summary>
        /// <returns></returns>
        public async Task StopAsync()
        {
            _logger.LogInformation("Stopping Application");
            await Task.CompletedTask;
        }
    }
}