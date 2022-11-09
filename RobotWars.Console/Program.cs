using RobotWars.Services.Interfaces;

namespace RobotWars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Bootstrapper.GetIocContainer();

            var gameService = container.GetInstance<IGameService>();

            gameService.Play();
        }
    }
}