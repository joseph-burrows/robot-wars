using RobotWars.Models;

namespace RobotWars
{
    public class Robot
    {
        public Heading Heading { get; set; }
        public IEnumerable<Command> Commands { get; set; }
        public Coordinate Position { get; set; }

        public override string ToString()
        {
            return $"{Position} {Heading}";
        }
    }
}
