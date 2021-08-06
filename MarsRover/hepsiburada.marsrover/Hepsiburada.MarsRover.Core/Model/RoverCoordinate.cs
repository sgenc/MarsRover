namespace Hepsiburada.MarsRover.Core.Model
{
    public class RoverCoordinate
    {
        private int coordinateX;
        private int coordinateY;

        public RoverCoordinate(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        public int CoordinateX 
        {
            get { return coordinateX; } 
        }

        public int CoordinateY 
        { 
            get { return coordinateY; }
        }
    }
}
