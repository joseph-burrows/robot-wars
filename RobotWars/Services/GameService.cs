using RobotWars.Models;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class GameService : IGameService
    {
        private readonly IGameBuilder _gameBuilder;
        private readonly IInputParser _inputParser;
        private readonly IGameEvaluator _gameEvaluator;
        private readonly IGameOutput _gameOutput;

        public GameService(
            IGameBuilder gameBuilder,
            IInputParser inputParser,
            IGameEvaluator gameEvaluator,
            IGameOutput gameOutput)
        {
            _gameBuilder = gameBuilder;
            _inputParser = inputParser;
            _gameEvaluator = gameEvaluator;
            _gameOutput = gameOutput;
        }

        public void Play()
        {
            var input = _inputParser.Parse();
            var game = _gameBuilder.Build(input);
            _gameEvaluator.Evaluate(game);
            _gameOutput.Output(game);
        }
    }
}
