using RobotWars.Models;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class GameOutput : IGameOutput
    {
        private readonly IConsole _console;

        public GameOutput(IConsole console)
        {
            _console = console;
        }

        public void Output(Game game)
        {
            game.Robots.ForEach(robot => _console.WriteLine(robot.ToString()));
        }
    }
}
