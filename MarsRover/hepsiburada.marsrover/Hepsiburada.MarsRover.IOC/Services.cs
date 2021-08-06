using FluentValidation;
using Hepsiburada.MarsRover.Core.Model;
using Hepsiburada.MarsRover.Validator.Validators;
using Hepsiburada.MarsRover.Service.Abstracts;
using Hepsiburada.MarsRover.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Hepsiburada.MarsRover.Core;

namespace Hepsiburada.MarsRover.IOC
{
    public static class Services
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<PlateauDimension>, PlateauDimensionValidator>();
            services.AddTransient<IValidator<UserPlateauDimensionInputModel>, PlateauDimensionFormatValidator>();
            services.AddTransient<IValidator<UserRoverCoordinatesInputModel>, RoverCoordinatesFormatValidator>();
            services.AddTransient<IValidator<UserRoverInstructionsInputModel>, RoverInstructionsFormatValidator>();

            services.AddTransient<IRoverService, RoverService>();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<IApplicationService, ApplicationService>();

            return services;
        }
    }
}
