using FluentAssertions;
using FluentValidation;
using Moq;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Services;
using System.Collections.Generic;

namespace RobotWars.Tests.Unit
{
    public class RobotBuilderTests
    {
        private RobotBuilder _robotBuilder;
        private readonly Mock<IValidator<Robot>> _mockValidator = new Mock<IValidator<Robot>>();

        [SetUp]
        public void SetUp()
        {
            _robotBuilder = new RobotBuilder(_mockValidator.Object);
        }

        [Test]
        public void Build_WithValidInputString_ReturnsArena()
        {
            // Arrange
            _mockValidator.Setup(x => x.Validate(It.IsAny<Robot>())).Returns(new FluentValidation.Results.ValidationResult());

            // Act
            var input = new string[]
            {
                "1 2 N",
                "LMLMLMLMM"
            };

            var robot = _robotBuilder.Build(input);

            // Assert
            robot.Position.Should().BeEquivalentTo(new Coordinate { X = 1, Y = 2 });
            robot.Heading.Should().Be(Heading.N);
            robot.Commands.Should().BeEquivalentTo(new List<Command>()
            {
                Command.L,
                Command.M,
                Command.L,
                Command.M,
                Command.L,
                Command.M,
                Command.L,
                Command.M,
                Command.M
            });
        }
    }
}
