using FluentAssertions;
using FluentValidation;
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

namespace RobotWars.Tests.Unit
{
    public class GameBuilderTests
    {

        private GameBuilder _gameBuilder;
        private readonly Mock<IArenaBuilder> _mockArenaBuilder = new Mock<IArenaBuilder>();
        private readonly Mock<IRobotBuilder> _mockRobotBuilder = new Mock<IRobotBuilder>();
        private readonly Mock<IValidator<Game>> _mockValidator = new Mock<IValidator<Game>>();

        [SetUp]
        public void SetUp()
        {
            _gameBuilder = new GameBuilder(
                _mockArenaBuilder.Object,
                _mockRobotBuilder.Object,
                _mockValidator.Object);
        }

        [Test]
        public void Build_WithValidInputStrings_ReturnsGame()
        {
            // Arrange
            var input = new List<string>
            {
                "5 5",
                "1 2 N",
                "M",
                "3 3 E",
                "M"
            };

            _mockValidator.Setup(x => x.Validate(It.IsAny<Game>())).Returns(new FluentValidation.Results.ValidationResult());

            _mockArenaBuilder.Setup(x => x.Build("5 5")).Returns(new Arena { Height = 5, Width = 5 });

            _mockRobotBuilder.Setup(x => x.Build(It.Is<string[]>(y => y[0] == "1 2 N" && y[1] == "M"))).Returns(new Robot
            {
                Position = new Coordinate { X = 1, Y = 2 },
                Heading = Heading.N,
                Commands = new List<Command> { Command.M }
            });

            _mockRobotBuilder.Setup(x => x.Build(It.Is<string[]>(y => y[0] == "3 3 E" && y[1] == "M"))).Returns(new Robot
            {
                Position = new Coordinate { X = 3, Y = 3 },
                Heading = Heading.E,
                Commands = new List<Command> { Command.M }
            });

            // Act
            var game = _gameBuilder.Build(input);

            // Assert
            _mockArenaBuilder.Verify(x => x.Build("5 5"), Times.Once);
            _mockRobotBuilder.Verify(x => x.Build(new string[] { "1 2 N", "M" }), Times.Once);
            _mockRobotBuilder.Verify(x => x.Build(new string[] { "3 3 E", "M" }), Times.Once);
        }

    }
}
