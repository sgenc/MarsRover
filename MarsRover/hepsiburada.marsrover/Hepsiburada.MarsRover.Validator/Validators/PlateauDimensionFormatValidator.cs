using FluentValidation;
using Hepsiburada.MarsRover.Core;
using System.Text.RegularExpressions;

namespace Hepsiburada.MarsRover.Validator.Validators
{
    public class PlateauDimensionFormatValidator : AbstractValidator<UserPlateauDimensionInputModel>
    {
        public PlateauDimensionFormatValidator()
        {
            RuleFor(x => x.PlateauDimension).Matches(@"^\d+ \d+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
    }
}
