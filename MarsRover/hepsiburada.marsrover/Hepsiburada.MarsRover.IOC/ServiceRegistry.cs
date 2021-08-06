using Microsoft.Extensions.DependencyInjection;

namespace Hepsiburada.MarsRover.IOC
{
    public class ServiceRegistry
    {
        public static void Register(IServiceCollection services)
        {
            services.RegisterApplicationServices();
        }
    }
}
