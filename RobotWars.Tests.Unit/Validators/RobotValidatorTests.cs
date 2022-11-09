using FluentAssertions;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*
        [Test]
        public void Validate_WithInvalidXPosition_ReturnsInvalidResult()
        {

        }

        [Test]
        public void Validate_WithInvalidYPosition_ReturnsInvalidResult()
        {

        }

        [Test]
        public void Validate_WithInvalidCommandsList_ReturnsInvalidResult()
        {

        }

        [Test]
        public void Validate_WithInvalidHeader_ReturnsInvalidResult()
        {

        }*/

    }
}
