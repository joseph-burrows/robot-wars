using Moq;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Services;
using RobotWars.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Tests.Unit.Services
{
    public class GameOutputTests
    {

        private IGameOutput _gameOutput;

        private readonly Mock<IConsole> _mockConsole = new Mock<IConsole>();

        [SetUp]
        public void SetUp()
        {
            _gameOutput = new GameOutput(_mockConsole.Object);
        }

        [Test]
        public void Output_WithValidGame_ShouldOutputResultsToConsole()
        {
            // Arrange
            var game = new Game
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
            };

            // Act
            _gameOutput.Output(game);

            // Assert
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "2 2 N")), Times.Once);
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "3 3 E")), Times.Once);
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "4 4 S")), Times.Once);
            _mockConsole.Verify(x => x.WriteLine(It.Is<string>(y => y == "5 5 W")), Times.Once);
        }

    }
}
