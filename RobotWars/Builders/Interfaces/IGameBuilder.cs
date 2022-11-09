using RobotWars.Models;

namespace RobotWars.Services
{
    public interface IGameBuilder
    {
        Game Build(List<string> input);
    }
}
