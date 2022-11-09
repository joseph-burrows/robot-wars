using FluentAssertions;
using Moq;
using NUnit.Framework;
using RobotWars.Services;
using System.Collections.Generic;

namespace RobotWars.Tests.Unit.Services
{
    public class ConsoleInputParserTests
    {
        private ConsoleInputParser _consoleInputParser;

        private Mock<IConsole> _mockConsole = new Mock<IConsole>();

        [SetUp]
        public void SetUp()
        {
            _consoleInputParser = new ConsoleInputParser(_mockConsole.Object);
        }

        [Test]
        public void Parse_WithValidConsoleInput_ShouldReturnAListOfStrings()
        {
            // Arrange
            _mockConsole.SetupSequence(x => x.ReadLine())
                .Returns("5 5")
                .Returns("1 2 N")
                .Returns("LMLMLMLMM")
                .Returns("3 3 E")
                .Returns("MMRMMRMRRM");

            // Act
            var output = _consoleInputParser.Parse();

            // Assert
            output.Should().BeEquivalentTo(new List<string>
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            });
        }

    }
}
