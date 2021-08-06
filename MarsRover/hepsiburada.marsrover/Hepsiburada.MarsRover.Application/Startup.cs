using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace hepsiburada.marsrover.application
{
    public class Startup
    {
        static void BuildConfig(IConfigurationBuilder builder)
        {
            // Check the current directory that the application is running on 
            // Then once the file 'appsetting.json' is found, we are adding it.
            // We add env variables, which can override the configs in appsettings.json
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }


        public static IHost CreateHostBuilder()
        {
            var builder = new ConfigurationBuilder();
            Startup.BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                    .Build();

            return host;
        }
    }
}
