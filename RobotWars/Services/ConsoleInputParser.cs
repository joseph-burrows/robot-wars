using RobotWars.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Services
{
    public class ConsoleInputParser : IInputParser
    {
        private readonly IConsole _console;
        public ConsoleInputParser(IConsole console)
        {
            _console = console;
        }

        public List<string> Parse()
        {
            var input = new List<string>();

            var currentLine = _console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                input.Add(currentLine);
                currentLine = _console.ReadLine();
            }

            return input;
        }
    }
}
