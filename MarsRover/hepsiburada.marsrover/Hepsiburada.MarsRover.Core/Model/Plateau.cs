using EnsureThat;
using System.Collections.Generic;

namespace Hepsiburada.MarsRover.Core.Model
{
    public class Plateau
    {
        private readonly List<Rover> rovers;

        private PlateauDimension dimensions;
        
        public Plateau(PlateauDimension dimensions)
        {
            Ensure.That(dimensions).IsNotNull();
            Ensure.That(dimensions.DimensionX).IsGt(0);
            Ensure.That(dimensions.DimensionY).IsGt(0);

            this.dimensions = dimensions;
            rovers = new List<Rover>();
        }

        public IReadOnlyCollection<Rover> Rovers
        {
            get { return rovers; }
        }

        public PlateauDimension Dimensions 
        {
            get { return this.dimensions; } 
        }

        public void AddRover(Rover rover)
        {
            if (rover != null)
                rovers.Add(rover);
        }
    }
}
