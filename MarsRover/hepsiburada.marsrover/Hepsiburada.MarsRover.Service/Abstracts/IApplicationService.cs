using Hepsiburada.MarsRover.Core.Model;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.Service.Abstracts
{
    public interface IApplicationService
    {
        bool GetPlateauDimension();

        Rover GetRover();

        IEnumerable<Rover> GetAllRovers();

        bool IsRoverInPlateau(Rover rover);
        
        bool ValidateRoverPosition(Rover rover);

        bool GetInstructionsAndAddRover(Rover rover);

    }
}
