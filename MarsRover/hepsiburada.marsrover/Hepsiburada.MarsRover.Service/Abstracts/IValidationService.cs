using Hepsiburada.MarsRover.Core;
using Hepsiburada.MarsRover.Core.Model;

namespace Hepsiburada.MarsRover.Service.Abstracts
{
    public interface IValidationService
    {
        bool ValidatePlateauDimension(PlateauDimension dimension);

        bool ValidatePlateauDimensionFormat(UserPlateauDimensionInputModel userPlateauDimension);

        bool ValidateRoverCoordinatesFormat(UserRoverCoordinatesInputModel userRoverCoordinates);

        bool ValidateRoverInstructionsFormat(UserRoverInstructionsInputModel userRoverInstructions);
    }
}
