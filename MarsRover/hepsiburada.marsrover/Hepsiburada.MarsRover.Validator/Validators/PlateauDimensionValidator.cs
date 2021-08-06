using FluentValidation;
using Hepsiburada.MarsRover.Core.Model;

namespace Hepsiburada.MarsRover.Validator.Validators
{
    public class PlateauDimensionValidator : AbstractValidator<PlateauDimension>
    {
        public PlateauDimensionValidator()
        {
            RuleFor(x => x.DimensionX).GreaterThan(0);
            RuleFor(x => x.DimensionY).GreaterThan(0);
        }
    }
}
