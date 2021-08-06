using Hepsiburada.MarsRover.IOC;
using Hepsiburada.MarsRover.Service.Abstracts;
using Hepsiburada.MarsRover.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Linq;

namespace Hepsiburada.MarsRover.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = AppStartup();

            var application = ActivatorUtilities.CreateInstance<ApplicationService>(host.Services);


            while (true)
            {
                if (!application.GetPlateauDimension())
                {
                    Console.WriteLine("Wrong dimension input, please try again");
                    continue;
                }

                while (true)
                {
                    var rover = application.GetRover();

                    if (rover != null &&
                        application.IsRoverInPlateau(rover) &&
                        application.ValidateRoverPosition(rover))
                    {
                        if (application.GetInstructionsAndAddRover(rover))
                        {
                            Console.WriteLine("If you want to add rover, please write 'yes'");
                            string userResponse = Console.ReadLine()?.Trim();

                            if (!string.IsNullOrEmpty(userResponse))
                            {
                                if (userResponse != "yes")
                                    break;
                            }
                        }
                        else
                            Console.WriteLine("Check rover position, rover is not in the plateua or there is another rover on the route");
                    }
                    else
                        Console.WriteLine("Check rover position, rover is not in the plateua or there is another rover on the route");
                }

                ListRoversOfPlateau(application);
                break;
            }
        }

        private static void ListRoversOfPlateau(IApplicationService application)
        {
            var rovers = application.GetAllRovers();

            if (rovers.ToList().Count() > 0)
            {
                foreach (var rover in rovers)
                    Console.WriteLine(rover.ToString());
            }
        }

        static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            ConfigSetup(builder);

            // defining Serilog configs
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            // Initiated the denpendency injection container 
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) => {
                            services.RegisterApplicationServices();
                        })
                        .UseSerilog()
                        .Build();

            return host;
        }
    }
}
