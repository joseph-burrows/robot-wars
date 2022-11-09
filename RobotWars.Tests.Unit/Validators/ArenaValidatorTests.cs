using FluentAssertions;
using NUnit.Framework;
using RobotWars.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Tests.Unit
{
    public class ArenaValidatorTests
    {
        [Test]
        public void Validate_WithValidObject_ReturnsValidResult()
        {
            // Arrange
            var robot = new Arena
            {
                Width = 5,
                Height = 5
            };
            var validator = new ArenaValidator();

            // Act
            var validationResult = validator.Validate(robot);

            // Assert
            validationResult.IsValid.Should().BeTrue();
        }

    }
}
