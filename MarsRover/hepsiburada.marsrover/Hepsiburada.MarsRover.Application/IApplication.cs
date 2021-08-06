using hepsiburada.marsrover.core.Model;

namespace hepsiburada.marsrover.application
{
    public interface IApplication
    {
        Dimension GetPlateauDimension();

        Rover GetRover();

        RoverInstructions GetInstructions();

        bool ValidateRoverPosition(Rover rover, IPlateau plateau);
    }
}
