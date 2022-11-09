using FluentValidation;
using RobotWars.Models;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class GameBuilder : IGameBuilder
    {
        private readonly IArenaBuilder _arenaBuilder;
        private readonly IRobotBuilder _robotBuilder;

        private readonly IValidator<Game> _validator;

        public GameBuilder(
            IArenaBuilder arenaBuilder,
            IRobotBuilder robotBuilder,
            IValidator<Game> validator)
        {
            _arenaBuilder = arenaBuilder;
            _robotBuilder = robotBuilder;
            _validator = validator;
        }

        public Game Build(List<string> input)
        {
            ValidateInput(input);

            var arena = GetArena(input);
            var robots = GetRobots(input);

            var game = new Game { Arena = arena, Robots = robots };

            Validate(game);

            return game;
        }

        private Arena GetArena(List<string> input)
        {
            return _arenaBuilder.Build(input[0]);
        }

        private List<Robot> GetRobots(List<string> input)
        {
            var robots = new List<Robot>();

            for (int i = 1; i < input.Count - 1; i+= 2)
            {
                var robot = _robotBuilder.Build(new string[] { input[i], input[i + 1] });
                robots.Add(robot);
            }

            return robots;
        }

        private void Validate(Game game)
        {
            var validationResult = _validator.Validate(game);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join('\n', validationResult.Errors.Select(x => x.ErrorMessage)));
            }
        }

        private void ValidateInput(List<string> input)
        {
            if (input.Count < 3) throw new ArgumentException("Not enough input arguments supplied");
            if (input.Count % 2 == 0) throw new ArgumentException("Not enough input arguments supplied");
        }

    }
}
