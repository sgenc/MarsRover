using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Hepsiburada.MarsRover.Core;
using Hepsiburada.MarsRover.Core.Model;
using Hepsiburada.MarsRover.Service.Services;
using Moq;
using Xunit;

namespace Hepsiburada.MarsRover.Test.ServiceTests
{
    public class ValidationServiceTests
    {
        [Theory]
        [InlineData(5, 5)]
        [InlineData(3, 5)]
        public void When_PlateauDimension_Is_Given_Then_Should_Be_Valid(int dimensionX, int dimensionY)
        {
            var plateauDimension = new PlateauDimension(dimensionX, dimensionY);

            var validaterMock = new Mock<IValidator<PlateauDimension>>(MockBehavior.Strict);
            validaterMock.Setup(s => s.Validate(plateauDimension)).Returns(new ValidationResult()).Verifiable();

            var validationService = new ValidationService(validaterMock.Object, null, null, null);
            var result = validationService.ValidatePlateauDimension(plateauDimension);

            validaterMock.Verify();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("5 5")]
        public void When_PlateauDimensionUserInput_Is_Given_Then_Should_Be_Valid(string userDimensionInput)
        {
            var userPlateauDimension = new UserPlateauDimensionInputModel() { PlateauDimension = userDimensionInput };

            var validaterMock = new Mock<IValidator<UserPlateauDimensionInputModel>>(MockBehavior.Strict);
            validaterMock.Setup(s => s.Validate(userPlateauDimension)).Returns(new ValidationResult()).Verifiable();

            var validationService = new ValidationService(null, validaterMock.Object, null, null);
            var result = validationService.ValidatePlateauDimensionFormat(userPlateauDimension);

            validaterMock.Verify();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("3 3 N")]
        public void When_RoverCoordinatesUserInput_Is_Given_Then_Should_Be_Valid(string userRoverCoordinatesInput)
        {
            var userRoverCoordinates = new UserRoverCoordinatesInputModel() { RoverCoordinates = userRoverCoordinatesInput };

            var validaterMock = new Mock<IValidator<UserRoverCoordinatesInputModel>>(MockBehavior.Strict);
            validaterMock.Setup(s => s.Validate(userRoverCoordinates)).Returns(new ValidationResult()).Verifiable();

            var validationService = new ValidationService(null, null, validaterMock.Object, null);
            var result = validationService.ValidateRoverCoordinatesFormat(userRoverCoordinates);

            validaterMock.Verify();
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("LMLMRM")]
        public void When_RoverInstructionsUserInput_Is_Given_Then_Should_Be_Valid(string userRoverInstructionsInput)
        {
            var userRoverInstructions = new UserRoverInstructionsInputModel() { RoverInstructions = userRoverInstructionsInput };

            var validaterMock = new Mock<IValidator<UserRoverInstructionsInputModel>>(MockBehavior.Strict);
            validaterMock.Setup(s => s.Validate(userRoverInstructions)).Returns(new ValidationResult()).Verifiable();

            var validationService = new ValidationService(null, null, null, validaterMock.Object);
            var result = validationService.ValidateRoverInstructionsFormat(userRoverInstructions);

            validaterMock.Verify();
            result.Should().BeTrue();
        }
    }
}
