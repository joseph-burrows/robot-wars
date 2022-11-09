using FluentAssertions;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Validators;
using System.Collections.Generic;

namespace RobotWars.Tests.Unit
{
    public class RobotValidatorTests
    {

        [Test]
        public void Validate_WithValidObject_ReturnsValidResult()
        {
            // Arrange
            var robot = new Robot
            {
                Commands = new List<Command> { Command.L, Command.R, Command.M },
                Heading = Heading.N,
                Position = new Coordinate { X = 1, Y = 1 }
            };
            var validator = new RobotValidator();

            // Act
            var validationResult = validator.Validate(robot);

            // Assert
            validationResult.IsValid.Should().BeTrue();
        }

        [Test]
        public void Validate_WithNullCommands_ReturnsInvalidResultWithErrors()
        {
            // Arrange
            var robot = new Robot
            {
                Commands = null,
                Heading = Heading.N,
                Position = new Coordinate { X = 1, Y = 1 }
            };
            var validator = new RobotValidator();

            // Act
            var validationResult = validator.Validate(robot);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("'Commands' must not be empty.");
        }

        [Test]
        public void Validate_WithNullPosition_ReturnsInvalidResultWithErrors()
        {
            // Arrange
            var robot = new Robot
            {
                Commands = new List<Command> { Command.L, Command.R, Command.M },
                Heading = Heading.N,
                Position = null
            };
            var validator = new RobotValidator();

            // Act
            var validationResult = validator.Validate(robot);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("'Position' must not be empty.");
        }
    }
}
