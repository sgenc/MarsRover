using FluentValidation;
using Hepsiburada.MarsRover.Core;
using Hepsiburada.MarsRover.Core.Model;
using Hepsiburada.MarsRover.Service.Abstracts;

namespace Hepsiburada.MarsRover.Service.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidator<PlateauDimension> plateauValidator;
        private readonly IValidator<UserPlateauDimensionInputModel> plateauFormatValidator;
        private readonly IValidator<UserRoverCoordinatesInputModel> roverCoordinatesFormatValidator;
        private readonly IValidator<UserRoverInstructionsInputModel> roverInstructionsFormatValidator;

        public ValidationService(
            IValidator<PlateauDimension> plateauValidator, 
            IValidator<UserPlateauDimensionInputModel> plateauFormatValidator,
            IValidator<UserRoverCoordinatesInputModel> roverCoordinatesFormatValidator,
            IValidator<UserRoverInstructionsInputModel> roverInstructionsFormatValidator)
        {
            this.plateauValidator = plateauValidator;
            this.plateauFormatValidator = plateauFormatValidator;
            this.roverCoordinatesFormatValidator = roverCoordinatesFormatValidator;
            this.roverInstructionsFormatValidator = roverInstructionsFormatValidator;
        }

        public bool ValidatePlateauDimension(PlateauDimension dimension)
        {
            return plateauValidator.Validate(dimension).IsValid;
        }

        public bool ValidatePlateauDimensionFormat(UserPlateauDimensionInputModel userPlateauDimension)
        {
            return plateauFormatValidator.Validate(userPlateauDimension).IsValid;
        }

        public bool ValidateRoverCoordinatesFormat(UserRoverCoordinatesInputModel userRoverCoordinates)
        {
            return roverCoordinatesFormatValidator.Validate(userRoverCoordinates).IsValid;
        }

        public bool ValidateRoverInstructionsFormat(UserRoverInstructionsInputModel userRoverInstructions)
        {
            return roverInstructionsFormatValidator.Validate(userRoverInstructions).IsValid;
        }
    }
}
