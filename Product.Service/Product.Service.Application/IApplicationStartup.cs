using System.Threading;
using System.Threading.Tasks;

namespace Product.Service.Application
{
    /// <summary>
    /// Interface for application startup
    /// </summary>
    public interface IApplicationStartup
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>A task that will only be compleated when the application has stopped</returns>
        Task RunAsync(CancellationToken token = default(System.Threading.CancellationToken));

        /// <summary>
        /// Graceful shutdown of the application
        /// </summary>
        Task StopAsync();
    }
}