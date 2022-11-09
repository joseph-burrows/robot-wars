using FluentValidation;
using RobotWars.Models;
using RobotWars.Services;
using RobotWars.Services.Interfaces;
using RobotWars.Validators;
using StructureMap;

namespace RobotWars
{
    public class Bootstrapper
    {
        public static Container GetIocContainer()
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.WithDefaultConventions();
                    scan.AssembliesFromApplicationBaseDirectory();
                });
            });

            container.Configure(config =>
            {
                config.For<IInputParser>().Use<ConsoleInputParser>();
                config.For<IConsole>().Use<ConsoleWrapper>();
                config.For<IValidator<Arena>>().Use<ArenaValidator>();
                config.For<IValidator<Robot>>().Use<RobotValidator>();
                config.For<IValidator<Game>>().Use<GameValidator>();
            });

            return container;

        }

    }
}
