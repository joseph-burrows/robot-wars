using System.Diagnostics.CodeAnalysis;

namespace RobotWars.Services
{
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
