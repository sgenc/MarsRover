using Hepsiburada.MarsRover.Core;
using Hepsiburada.MarsRover.Core.Model;
using Hepsiburada.MarsRover.Service.Abstracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hepsiburada.MarsRover.Service.Services
{

    public class BaseApplicationService
    {
        protected static Plateau plateau;
        protected readonly IRoverService roverService;
        protected readonly IValidationService validationService;
        protected readonly ILogger<ApplicationService> logger;

        protected BaseApplicationService()
        {

        }

        protected BaseApplicationService(IRoverService roverService, IValidationService validationService, ILogger<ApplicationService> logger)
        {
            this.roverService = roverService;
            this.validationService = validationService;
            this.logger = logger;
        }

        protected void AddRover(Rover rover)
        {
            if (rover != null)
                plateau.AddRover(rover);
        }

        protected RoverInstructions GetInstructions()
        {
            Console.WriteLine("Please enter rover instructions");

            var userRoverInsructions = new UserRoverInstructionsInputModel() { RoverInstructions = Console.ReadLine() };

            if (!String.IsNullOrEmpty(userRoverInsructions.RoverInstructions) && this.validationService.ValidateRoverInstructionsFormat(userRoverInsructions))
            {
                return new RoverInstructions(userRoverInsructions.RoverInstructions);
            }
            else
                return null;
        }

        protected Rover CalculateDirection(Rover rover, char route)
        {
            return this.roverService.CalculateDirection(rover, route);
        }

        protected Rover MoveRover(Rover rover)
        {
            return this.roverService.MoveRover(rover);
        }
    }

    public class ApplicationService : BaseApplicationService, IApplicationService
    {
        public ApplicationService(IRoverService roverService, IValidationService validationService, ILogger<ApplicationService> logger)
            :base(roverService, validationService, logger)
        {

        }

        public bool GetPlateauDimension()
        {
            try
            {
                Console.WriteLine("Please enter plateau dimensions. Example dimension input: 4 4");
                var userPlateauDimension = new UserPlateauDimensionInputModel() { PlateauDimension = Console.ReadLine() };

                PlateauDimension plateauDimension;
                if (this.validationService.ValidatePlateauDimensionFormat(userPlateauDimension))
                {
                    var splittedDimension = userPlateauDimension.PlateauDimension.Split(' ');

                    plateauDimension = new PlateauDimension(Int32.Parse(splittedDimension[0]), Int32.Parse(splittedDimension[1]));
                }
                else
                    return false;

                if (plateauDimension != null && this.validationService.ValidatePlateauDimension(plateauDimension))
                {
                    plateau = new Plateau(plateauDimension);

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
               logger.LogError(ex.Message);
            }

            return false;
        }

        public Rover GetRover()
        {
            try
            {
                Console.WriteLine("Please enter rover initial coordinates");

                var userRoverCoordinates = new UserRoverCoordinatesInputModel() { RoverCoordinates = Console.ReadLine() };

                RoverCoordinate roverCoordinates;
                if (this.validationService.ValidateRoverCoordinatesFormat(userRoverCoordinates))
                {
                    var splittedRoverCoordinates = userRoverCoordinates.RoverCoordinates.Split(' ');

                    roverCoordinates = new RoverCoordinate(Int32.Parse(splittedRoverCoordinates[0]), Int32.Parse(splittedRoverCoordinates[1]));

                    var roverDirection = splittedRoverCoordinates[2];

                    return new Rover(roverCoordinates, (RoverDirection)Enum.Parse(typeof(RoverDirection), roverDirection));
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return null;
        }

        public IEnumerable<Rover> GetAllRovers()
        {
            return plateau.Rovers;
        }

        public bool GetInstructionsAndAddRover(Rover rover)
        {
            try
            {
                var roverValidated = true;

                var roverInstructions = GetInstructions();

                if (roverInstructions != null)
                {
                    foreach (var item in roverInstructions.Instructions)
                    {
                        if (item.Equals('L') || item.Equals('R'))
                        {
                            rover = CalculateDirection(rover, item);

                            roverValidated = IsRoverInPlateau(rover) && ValidateRoverPosition(rover);
                        }
                        else
                        {
                            rover = MoveRover(rover);
                        }
                    }
                }

                if (roverValidated)
                {
                    AddRover(rover);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return false;
        }

        public bool IsRoverInPlateau(Rover rover)
        {
            return rover.RoverCoordinates.CoordinateX <= plateau.Dimensions.DimensionX && rover.RoverCoordinates.CoordinateX >= 0
                    && rover.RoverCoordinates.CoordinateY <= plateau.Dimensions.DimensionY && rover.RoverCoordinates.CoordinateY >= 0;
        }

        public bool ValidateRoverPosition(Rover rover)
        {
            var rovers = plateau.Rovers;

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
