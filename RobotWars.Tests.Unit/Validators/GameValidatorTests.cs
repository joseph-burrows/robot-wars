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

        [Test]
        public void Validate_WithRobotPositionOutsideRightBound_ReturnsInvalidResultWithErrors()
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
                        Position = new Coordinate{ X = 6, Y = 1 }
                    }
                }
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("All robots must be in bounds");
        }

        [Test]
        public void Validate_WithRobotPositionOutsideLeftBound_ReturnsInvalidResultWithErrors()
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
                        Position = new Coordinate{ X = -1, Y = 1 }
                    }
                }
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("All robots must be in bounds");
        }

        [Test]
        public void Validate_WithRobotPositionOutsideTopBound_ReturnsInvalidResultWithErrors()
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
                        Position = new Coordinate{ X = 3, Y = 6 }
                    }
                }
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("All robots must be in bounds");
        }

        [Test]
        public void Validate_WithRobotPositionOutsideBottomBound_ReturnsInvalidResultWithErrors()
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
                        Position = new Coordinate{ X = 3, Y = -1 }
                    }
                }
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("All robots must be in bounds");
        }

        [Test]
        public void Validate_WithNullArena_ReturnsInvalidResultWithErrors()
        {
            // Arrange
            var game = new Game
            {
                Arena = null,
                Robots = new List<Robot>
                {
                    new Robot
                    {
                        Heading = Heading.N,
                        Commands = new List<Command>(){ Command.M },
                        Position = new Coordinate{ X = 6, Y = 1 }
                    }
                }
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("'Arena' must not be empty.");
        }

        [Test]
        public void Validate_WithNullRobots_ReturnsInvalidResultWithErrors()
        {
            // Arrange
            var game = new Game
            {
                Arena = new Arena { Width = 5, Height = 5 },
                Robots = null
            };

            var validator = new GameValidator();

            // Act
            var validationResult = validator.Validate(game);

            // Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors[0].ErrorMessage.Should().Be("'Robots' must not be empty.");
        }
    }
}
