using FluentAssertions;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Validators;
using System.Collections.Generic;

namespace RobotWars.Tests.Unit
{
    public class GameValidatorTests
    {
        [Test]
        public void Validate_WithValidObject_ReturnsValidResult()
        {
            // Arrange
            var game = new Game
            {
                Arena = new Arena { Width = 5, Height = 5 },
                Robots = new List<Robot>
                {
                    new Robot
                    {
                        Heading = Heading.N,
                        Commands = new List<Command>(){ Command.M },
                        Position = new Coordinate{ X = 1, Y = 1 }
                    }
                }
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeTrue();
        }
    }
}
