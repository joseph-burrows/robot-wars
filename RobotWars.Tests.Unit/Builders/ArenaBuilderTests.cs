using FluentAssertions;
using FluentValidation;
using Moq;
using NUnit.Framework;
using RobotWars.Services;

namespace RobotWars.Tests.Unit
{
    public class ArenaBuilderTests
    {

        private ArenaBuilder _arenaBuilder;
        private readonly Mock<IValidator<Arena>> _mockValidator = new Mock<IValidator<Arena>>();

        [SetUp]
        public void SetUp()
        {
            _arenaBuilder = new ArenaBuilder(_mockValidator.Object);
        }

        [Test]
        public void Build_WithValidInputString_ReturnsArena()
        {
            // Arrange
            _mockValidator.Setup(x => x.Validate(It.IsAny<Arena>())).Returns(new FluentValidation.Results.ValidationResult());

            // Act
            var arena = _arenaBuilder.Build("5 5");

            // Assert
            arena.Width.Should().Be(5);
            arena.Height.Should().Be(5);
        }
    }
}
