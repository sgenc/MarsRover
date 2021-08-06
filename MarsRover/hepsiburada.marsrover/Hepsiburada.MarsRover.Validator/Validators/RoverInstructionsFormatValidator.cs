using FluentValidation;
using Hepsiburada.MarsRover.Core;
using System.Text.RegularExpressions;

namespace Hepsiburada.MarsRover.Validator.Validators
{
    public class RoverInstructionsFormatValidator : AbstractValidator<UserRoverInstructionsInputModel>
    {
        public RoverInstructionsFormatValidator()
        {
            RuleFor(x => x.RoverInstructions).Matches(@"^[LMR]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}
