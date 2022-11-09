using RobotWars.Services;
using RobotWars.Services.Interfaces;
using System;

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