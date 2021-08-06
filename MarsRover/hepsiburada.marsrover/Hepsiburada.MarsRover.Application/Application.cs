using hepsiburada.marsrover.core.Model;
using System;
using System.Linq;

namespace hepsiburada.marsrover.application
{
    public class Application : IApplication
    {

        public RoverInstructions GetInstructions()
        {
            Console.WriteLine("Please enter rover instructions");

            var roverInstructions = Console.ReadLine();

            // Validate user input

            return new RoverInstructions(roverInstructions);
        }

        public Dimension GetPlateauDimension()
        {
            Console.WriteLine("Please enter plateau dimensions");

            var plateauDimension = Console.ReadLine();

            // Validate user input

            var splittedDimension = plateauDimension.Split(' ');

            return new Dimension(Int32.Parse(splittedDimension[0]), Int32.Parse(splittedDimension[1]));
        }

        public Rover GetRover()
        {
            Console.WriteLine("Please enter rover initial coordinates");

            var roverCoordinates = Console.ReadLine();

            // Validate user input

            var splittedRoverCoordinates = roverCoordinates.Split(' ');

            var roverCoordinate = new RoverCoordinate(Int32.Parse(splittedRoverCoordinates[0]), Int32.Parse(splittedRoverCoordinates[1]));

            var orientation = splittedRoverCoordinates[2];

            return new Rover(roverCoordinate, (RoverDirection)Enum.Parse(typeof(RoverDirection), orientation));

        }

        public bool ValidateRoverPosition(Rover rover, IPlateau plateau)
        {
            var rovers = plateau.GetRovers();

            if (rovers.Any())
            {
                return rovers.Any(s => s.RoverCoordinates.CoordinateX == rover.RoverCoordinates.CoordinateX && s.RoverCoordinates.CoordinateY == rover.RoverCoordinates.CoordinateY) ? false : true;
            }
            else
            {
                return true;
            }
        }
    }
}
