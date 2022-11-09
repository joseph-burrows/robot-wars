using FluentAssertions;
using NUnit.Framework;
using RobotWars.Models;
using RobotWars.Services;
using RobotWars.Services.Interfaces;
using System.Collections.Generic;

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
            var robot1 = GetRobotWithPosition(1, 2, Heading.N);
            robot1.Commands = new List<Command> { Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.M };

            var robot2 = GetRobotWithPosition(3, 3, Heading.E);
            robot2.Commands = new List<Command> { Command.M, Command.M, Command.R, Command.M, Command.M, Command.R, Command.M, Command.R, Command.R, Command.M };

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

        [Test]
        public void Evaluate_WithRobotMovingTowardsRightEdge_ReturnsWithinBounds()
        {
            // Arrange
            var arena = new Arena { Height = 5, Width = 5 };
            var robot1 = GetRobotWithPosition(4, 2, Heading.E);
            robot1.Commands = new List<Command> { Command.M, Command.M, Command.M, Command.M, Command.M };

            var game = new Game { Arena = arena, Robots = new List<Robot> { robot1 } };

            // Act
            _gameEvaluator.Evaluate(game);

            // Assert
            game.Robots[0].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 5, Y = 2 },
                Heading = Heading.E
            }, options => options.Excluding(y => y.Commands));

        }

        [Test]
        public void Evaluate_WithRobotMovingTowardsLeftEdge_ReturnsWithinBounds()
        {
            // Arrange
            var arena = new Arena { Height = 5, Width = 5 };
            var robot1 = GetRobotWithPosition(2, 2, Heading.W);
            robot1.Commands = new List<Command> { Command.M, Command.M, Command.M, Command.M, Command.M };

            var game = new Game { Arena = arena, Robots = new List<Robot> { robot1 } };

            // Act
            _gameEvaluator.Evaluate(game);

            // Assert
            game.Robots[0].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 0, Y = 2 },
                Heading = Heading.W
            }, options => options.Excluding(y => y.Commands));
        }

        [Test]
        public void Evaluate_WithRobotMovingTowardsTopEdge_ReturnsWithinBounds()
        {
            // Arrange
            var arena = new Arena { Height = 5, Width = 5 };
            var robot1 = GetRobotWithPosition(2, 4, Heading.N);
            robot1.Commands = new List<Command> { Command.M, Command.M, Command.M, Command.M, Command.M };

            var game = new Game { Arena = arena, Robots = new List<Robot> { robot1 } };

            // Act
            _gameEvaluator.Evaluate(game);

            // Assert
            game.Robots[0].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 2, Y = 5 },
                Heading = Heading.N
            }, options => options.Excluding(y => y.Commands));
        }

        [Test]
        public void Evaluate_WithRobotMovingTowardsBottomEdge_ReturnsWithinBounds()
        {
            // Arrange
            var arena = new Arena { Height = 5, Width = 5 };
            var robot1 = GetRobotWithPosition(2, 1, Heading.S);
            robot1.Commands = new List<Command> { Command.M, Command.M, Command.M, Command.M, Command.M };

            var game = new Game { Arena = arena, Robots = new List<Robot> { robot1 } };

            // Act
            _gameEvaluator.Evaluate(game);

            // Assert
            game.Robots[0].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 2, Y = 0 },
                Heading = Heading.S
            }, options => options.Excluding(y => y.Commands));
        }

        [Test]
        public void Evaluate_WithRobotsMovingTowardsEachother_ReturnsAsExpected()
        {
            // Arrange
            var arena = new Arena { Height = 5, Width = 5 };
            var robot1 = GetRobotWithPosition(3, 3, Heading.E);
            robot1.Commands = new List<Command> { Command.M, Command.M, Command.M, Command.M, Command.M };

            var robot2 = GetRobotWithPosition(4, 3, Heading.W);
            robot2.Commands = new List<Command> { Command.M, Command.M, Command.M, Command.M, Command.M };

            var game = new Game { Arena = arena, Robots = new List<Robot> { robot1, robot2 } };

            // Act
            _gameEvaluator.Evaluate(game);

            // Assert
            game.Robots[0].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 3, Y = 3 },
                Heading = Heading.E
            }, options => options.Excluding(y => y.Commands));

            game.Robots[1].Should().BeEquivalentTo(new Robot
            {
                Position = new Coordinate { X = 4, Y = 3 },
                Heading = Heading.W
            }, options => options.Excluding(y => y.Commands));
        }

        private Robot GetRobotWithPosition(int x, int y, Heading heading)
        {
            var robot = new Robot
            {
                Position = new Coordinate { X = x, Y = y },
                Heading = heading
            };
            return robot;
        }
    }
}
