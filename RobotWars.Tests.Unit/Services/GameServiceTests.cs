using Moq;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Services;
using RobotWars.Services.Interfaces;
using System.Collections.Generic;

namespace RobotWars.Tests.Unit.Services
{
    public class GameServiceTests
    {
        private IGameService _gameService;

        private Mock<IConsole> _mockConsole = new Mock<IConsole>();
        private Mock<IGameBuilder> _mockGameBuilder = new Mock<IGameBuilder>();
        private Mock<IInputParser> _mockInputParser = new Mock<IInputParser>();
        private Mock<IGameEvaluator> _mockGameEvaluator = new Mock<IGameEvaluator>();

        [SetUp]
        public void SetUp()
        {
            _gameService = new GameService(
                _mockConsole.Object,
                _mockGameBuilder.Object,
                _mockInputParser.Object,
                _mockGameEvaluator.Object);
        }

        [Test]
        public void Play_WithValidInput_ShouldWriteOutputToConsole()
        {
            // Arrange
            _mockGameBuilder.Setup(x => x.Build(It.IsAny<List<string>>())).Returns(
                new Game
                {
                    Arena = new Arena { Height = 5, Width = 5 },
                    Robots = new List<Robot>
                    {
                        new Robot
                        {
                            Position = new Coordinate { X = 2, Y = 2 },
                            Heading = Heading.N,
                            Commands = new List<Command>()
                        },
                        new Robot
                        {
                            Position = new Coordinate { X = 3, Y = 3 },
                            Heading = Heading.E,
                            Commands = new List<Command>()
                        },
                        new Robot
                        {
                            Position = new Coordinate { X = 4, Y = 4 },
                            Heading = Heading.S,
                            Commands = new List<Command>()
                        },
                        new Robot
                        {
                            Position = new Coordinate { X = 5, Y = 5 },
                            Heading = Heading.W,
                            Commands = new List<Command>()
                        }
                    }
                });

            // Act
            _gameService.Play();

            // Assert
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "2 2 N")), Times.Once);
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "3 3 E")), Times.Once);
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "4 4 S")), Times.Once);
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "5 5 W")), Times.Once);
        }
    }
}
