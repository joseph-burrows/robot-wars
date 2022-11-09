using RobotWars.Models;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class GameService : IGameService
    {
        private readonly IConsole _console;
        private readonly IGameBuilder _gameBuilder;
        private readonly IInputParser _inputParser;
        private readonly IGameEvaluator _gameEvaluator;

        public GameService(
            IConsole console,
            IGameBuilder gameBuilder,
            IInputParser inputParser,
            IGameEvaluator gameEvaluator)
        {
            _console = console;
            _gameBuilder = gameBuilder;
            _inputParser = inputParser;
            _gameEvaluator = gameEvaluator;
        }

        public void Play()
        {
            var input = _inputParser.Parse();
            var game = _gameBuilder.Build(input);
            _gameEvaluator.Evaluate(game);
            OutputResults(game);
        }

        private void OutputResults(Game game)
        {
            game.Robots.ForEach(x => _console.WriteLine(x.ToString()));
        }
    }
}
