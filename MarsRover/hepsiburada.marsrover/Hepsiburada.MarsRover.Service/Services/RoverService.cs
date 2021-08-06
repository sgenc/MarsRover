using Hepsiburada.MarsRover.Core.Model;
using Hepsiburada.MarsRover.Service.Abstracts;
using System;

namespace Hepsiburada.MarsRover.Service.Services
{
    public class RoverService : IRoverService
    {
        public Rover CalculateDirection(Rover rover, char route)
        {
            const string allDirections = "WNES"; //West,North,East,South

            string responseDirection = "";

            for (int i = 0; i < 4; i++)
            {
                if (Enum.GetName(typeof(RoverDirection), rover.RoverDirection) == allDirections[i].ToString())
                {
                    responseDirection = route switch
                    {
                        'L' when i == 0 => allDirections[3].ToString(),
                        'L' => allDirections[i - 1].ToString(),
                        'R' when i == 3 => allDirections[0].ToString(),
                        'R' => allDirections[i + 1].ToString(),
                        _ => responseDirection
                    };
                }
            }

            return new Rover(rover.RoverCoordinates, (RoverDirection)Enum.Parse(typeof(RoverDirection), responseDirection));
        }

        public Rover MoveRover(Rover rover)
        {
            var roverCoordinateX = rover.RoverCoordinates.CoordinateX;
            var roverCoordinateY = rover.RoverCoordinates.CoordinateY;

            switch (rover.RoverDirection.ToString())
            {
                case "N":
                    roverCoordinateY += 1;
                    break;
                case "E":
                    roverCoordinateX += 1;
                    break;
                case "S":
                    roverCoordinateY -= 1;
                    break;
                case "W":
                    roverCoordinateX -= 1;
                    break;
            }

            return new Rover(new RoverCoordinate(roverCoordinateX, roverCoordinateY), rover.RoverDirection);
        }
    }
}
