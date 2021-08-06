namespace Hepsiburada.MarsRover.Core.Model
{
    public class Rover
    {
        private RoverCoordinate roverCoordinates;
        private RoverDirection roverDirection;

        public Rover(RoverCoordinate roverCoordinates, RoverDirection roverDirection)
        {
            this.roverCoordinates = roverCoordinates;
            this.roverDirection = roverDirection;
        }

        public RoverCoordinate RoverCoordinates 
        {
            get { return this.roverCoordinates; }
        }

        public RoverDirection RoverDirection 
        {
            get { return this.roverDirection; }
        }

        public override string ToString()
        {
            return $"{this.roverCoordinates.CoordinateX} {this.roverCoordinates.CoordinateY} {this.roverDirection}"; 
        }
    }
}
