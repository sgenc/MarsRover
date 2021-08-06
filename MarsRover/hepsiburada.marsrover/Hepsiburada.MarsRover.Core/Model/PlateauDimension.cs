namespace Hepsiburada.MarsRover.Core.Model
{
    public class PlateauDimension
    {
        private int dimensionX;
        private int dimensionY;

        public PlateauDimension(int dimensionX, int dimensionY)
        {
            this.dimensionX = dimensionX;
            this.dimensionY = dimensionY;
        }

        public int DimensionX 
        {
            get { return dimensionX; }
        }

        public int DimensionY 
        {
            get { return dimensionY; } 
        }
    }
}
