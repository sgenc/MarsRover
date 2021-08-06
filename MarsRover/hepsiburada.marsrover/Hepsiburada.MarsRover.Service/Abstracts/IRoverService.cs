using Hepsiburada.MarsRover.Core.Model;

namespace Hepsiburada.MarsRover.Service.Abstracts
{
    public interface IRoverService
    {
        Rover MoveRover(Rover rover);

        Rover CalculateDirection(Rover rover, char route);
    }
}
