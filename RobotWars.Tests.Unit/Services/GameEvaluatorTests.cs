using FluentAssertions;
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
    public class GameEvaluatorTests
    {
        private IGameEvaluator _gameEvaluator;

        [SetUp]
        public void SetUp()
        {
            _gameEvaluator = new GameEvaluator();
        }

        [Test]
        public void Evaluate_WithValidGame_ReturnsExpectedResult()
        {
            // Arrange
            var arena = new Arena { Height = 5, Width = 5 };
            var robot1 = new Robot
            {
                Position = new Coordinate { X = 1, Y = 2 },
                Heading = Heading.N,
                Commands = new List<Command>
                {
                    Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.M
                }
            };

            var robot2 = new Robot
            {
                Position = new Coordinate { X = 3, Y = 3 },
                Heading = Heading.E,
                Commands = new List<Command>
                {
                    Command.M, Command.M, Command.R, Command.M, Command.M, Command.R, Command.M, Command.R, Command.R, Command.M
                }
            };

            var game = new Game { Arena = arena, Robots = new List<Robot> { robot1, robot2 } };

            // Act
            _gameEvaluator.Evaluate(game);

            // Assert
            game.Robots[0].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 1, Y = 3 },
                Heading = Heading.N
            }, options => options.Excluding(y => y.Commands));

            game.Robots[1].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 5, Y = 1 },
                Heading = Heading.E
            }, options => options.Excluding(y => y.Commands));

        }
    }
}
