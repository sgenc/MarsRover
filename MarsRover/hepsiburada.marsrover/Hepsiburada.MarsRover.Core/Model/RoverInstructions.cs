namespace Hepsiburada.MarsRover.Core.Model
{
    public class RoverInstructions
    {
        private string instructions;

        public RoverInstructions(string instructions)
        {
            this.instructions = instructions;
        }

        public string Instructions
        {
            get { return instructions; }
        }
    }
}
