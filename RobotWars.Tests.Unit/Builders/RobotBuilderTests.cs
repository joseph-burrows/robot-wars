using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Services;
using System;
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
            _mockValidator.Setup(x => x.Validate(It.IsAny<Robot>())).Returns(new ValidationResult());

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

        [Test]
        public void Build_WithInvalidHeaderString_ThrowsArgumentException()
        {
            // Arrange
            _mockValidator.Setup(x => x.Validate(It.IsAny<Robot>())).Returns(new ValidationResult());

            // Act
            var input = new string[]
            {
                "1 2 Z",
                "LMLMLMLMM"
            };

            var action = () => _robotBuilder.Build(input);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("Unable to parse heading");
        }

        [Test]
        public void Build_WithInvalidCommandsString_ThrowsArgumentException()
        {
            // Arrange
            _mockValidator.Setup(x => x.Validate(It.IsAny<Robot>())).Returns(new ValidationResult());

            // Act
            var input = new string[]
            {
                "1 2 N",
                "LMLMZLMM"
            };

            var action = () => _robotBuilder.Build(input);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("Unable to parse command");
        }

        [Test]
        public void Build_WithValidationErrors_ThrowsArgumentException()
        {
            // Arrange
            var validationResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("test", "test") });
            _mockValidator.Setup(x => x.Validate(It.IsAny<Robot>())).Returns(validationResult);

            // Act
            var input = new string[]
            {
                "1 2 N",
                "LMLMLMLMM"
            };

            var action = () => _robotBuilder.Build(input);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("test");
        }
    }
}
