using FluentValidation;
using RobotWars.Models;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class RobotBuilder : IRobotBuilder
    {
        private readonly IValidator<Robot> _robotValidator;
        public RobotBuilder(IValidator<Robot> robotValidator)
        {
            _robotValidator = robotValidator;
        }

        public Robot Build(string[] input)
        {
            var positionInformation = input[0].Split(' ');
            var commandInformation = input[1];

            var position = GetPosition(positionInformation);
            var heading = GetHeading(positionInformation);
            var commands = GetCommands(commandInformation);

            var robot = new Robot { Heading = heading, Position = position, Commands = commands };

            Validate(robot);

            return robot;
        }

        private Coordinate GetPosition(string[] positionInformation)
        {
            return new Coordinate { X = Int32.Parse(positionInformation[0]), Y = Int32.Parse(positionInformation[1]) };
        }

        private Heading GetHeading(string[] positionInformation)
        {
            var success = Enum.TryParse(positionInformation[2], out Heading heading);
            if (!success) throw new ArgumentException("Unable to parse heading");
            return heading;
        }

        private IEnumerable<Command> GetCommands(string input)
        {
            var commandInformation = input.ToArray();
            var commands = new List<Command>();
            foreach (var command in commandInformation)
            {
                var success = Enum.TryParse(command.ToString(), out Command c);
                if (!success) throw new ArgumentException("Unable to parse command");
                commands.Add(c);
            }
            return commands;
        }

        private void Validate(Robot robot)
        {
            var validationResult = _robotValidator.Validate(robot);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join('\n', validationResult.Errors.Select(x => x.ErrorMessage)));
            }
        }
    }
}
