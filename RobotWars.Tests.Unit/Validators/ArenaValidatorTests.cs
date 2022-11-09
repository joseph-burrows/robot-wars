using FluentAssertions;
using NUnit.Framework;
using RobotWars.Validators;

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

        [Test]
        public void Validate_WithInvalidHeight_ReturnsInvalidResultWithErrors()
        {
            // Arrange
            var robot = new Arena
            {
                Width = 5,
                Height = -5
            };
            var validator = new ArenaValidator();

            // Act
            var validationResult = validator.Validate(robot);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("'Height' must be greater than '0'.");
        }

        [Test]
        public void Validate_WithInvalidWidth_ReturnsInvalidResultWithErrors()
        {
            // Arrange
            var robot = new Arena
            {
                Width = -5,
                Height = 5
            };
            var validator = new ArenaValidator();

            // Act
            var validationResult = validator.Validate(robot);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("'Width' must be greater than '0'.");
        }

    }
}
