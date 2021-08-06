using FluentAssertions;
using Hepsiburada.MarsRover.Core.Model;
using Hepsiburada.MarsRover.Service.Services;
using Moq;
using Xunit;

namespace Hepsiburada.MarsRover.Test.ServiceTests
{
    public class RoverServiceTests
    {
        [Theory]
        [InlineData(RoverDirection.N, 'L', RoverDirection.W)]
        [InlineData(RoverDirection.N, 'R', RoverDirection.E)]
        [InlineData(RoverDirection.S, 'R', RoverDirection.W)]
        public void When_RoverInformation_Is_Given_Then_Direction_Should_Be_Calculated(RoverDirection currrentDirection, char route, RoverDirection expectedDirection)
        {
            var rover = new Rover(new RoverCoordinate(It.IsAny<int>(), It.IsAny<int>()), currrentDirection);

            var expectedRover = new Rover(new RoverCoordinate(It.IsAny<int>(), It.IsAny<int>()), expectedDirection);

            var roverService = new RoverService();
            var result = roverService.CalculateDirection(rover, route);

            result.Should().NotBeNull();
            result.RoverDirection.Should().Be(expectedRover.RoverDirection);
        }

        [Theory]
        [InlineData(RoverDirection.N, 1, 1, 1, 2)]
        [InlineData(RoverDirection.S, 2, 3, 2, 2)]
        [InlineData(RoverDirection.E, 1, 1, 2, 1)]
        public void When_RoverInformation_Is_Given_Then_Coordinates_Should_Be_Calculated(RoverDirection roverDirection, int coordinateX, int coordinateY, int expectedCoordinateX, int expectedCoordinateY)
        {
            var rover = new Rover(new RoverCoordinate(coordinateX, coordinateY), roverDirection);

            var expectedRover = new Rover(new RoverCoordinate(expectedCoordinateX, expectedCoordinateY), roverDirection);

            var roverService = new RoverService();
            var result = roverService.MoveRover(rover);

            result.RoverCoordinates.Should().NotBeNull();
            result.RoverCoordinates.CoordinateX.Should().Be(expectedCoordinateX);
            result.RoverCoordinates.CoordinateY.Should().Be(expectedCoordinateY);
        }
    }
}
