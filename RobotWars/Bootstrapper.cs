using RobotWars.Services;
using RobotWars.Services.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            });

            return container;

        }

    }
}
