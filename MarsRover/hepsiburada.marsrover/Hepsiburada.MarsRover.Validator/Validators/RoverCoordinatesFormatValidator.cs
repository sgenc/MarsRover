using FluentValidation;
using Hepsiburada.MarsRover.Core;
using System.Text.RegularExpressions;

namespace Hepsiburada.MarsRover.Validator.Validators
{
    public class RoverCoordinatesFormatValidator : AbstractValidator<UserRoverCoordinatesInputModel>
    {
        public RoverCoordinatesFormatValidator()
        {
            RuleFor(x => x.RoverCoordinates).Matches(@"^\d+ \d+ [NESW]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}
