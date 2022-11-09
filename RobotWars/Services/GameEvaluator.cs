using RobotWars.Models;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class GameEvaluator : IGameEvaluator
    {
        private static Dictionary<Heading, Coordinate> _directions = new Dictionary<Heading, Coordinate>
        {
            { Heading.N, new Coordinate { X = 0, Y = 1 } },
            { Heading.E, new Coordinate { X = 1, Y = 0 } },
            { Heading.S, new Coordinate { X = 0, Y = -1 } },
            { Heading.W, new Coordinate { X = -1, Y = 0 } }
        };

        public void Evaluate(Game game)
        {
            var occupiedPositions = new HashSet<string>();

            game.Robots.ForEach(robot => occupiedPositions.Add(robot.Position.ToString()));

            game.Robots.ForEach(robot => RunCommands(robot, game.Arena, occupiedPositions));

            return;
        }

        private void RunCommands(Robot robot, Arena arena, HashSet<string> occupiedPositions)
        {

            occupiedPositions.Remove(robot.Position.ToString());
            var moves = new Queue<Command>(robot.Commands);

            while(moves.Count > 0)
            {
                var move = moves.Dequeue();

                switch (move)
                {
                    case Command.L:
                        robot.Heading = RotateHeading(robot.Heading, -1);
                        break;

                    case Command.R:
                        robot.Heading = RotateHeading(robot.Heading, 1);
                        break;

                    case Command.M:
                        Move(robot, arena, occupiedPositions);
                        break;
                }

            }

            occupiedPositions.Add(robot.Position.ToString());

        }

        private void Move(Robot robot, Arena arena, HashSet<string> occupiedPositions)
        {
            var potentialPosition = new Coordinate
            {
                X = robot.Position.X + _directions[robot.Heading].X,
                Y = robot.Position.Y + _directions[robot.Heading].Y
            };

            if (IsValid(potentialPosition, arena, occupiedPositions))
            {
                robot.Position = potentialPosition;
            }
        }

        private bool IsValid(Coordinate position, Arena arena, HashSet<string> occupiedPositions)
        {
            if (position.X < 0 || position.X > arena.Width) return false;
            if (position.Y < 0 || position.Y > arena.Height) return false;
            if (occupiedPositions.Contains(position.ToString())) return false;

            return true;
        }

        private Heading RotateHeading(Heading start, int rotation)
        {
            Heading newHeading = start + rotation;

            if ((int) newHeading > 3) newHeading = (Heading) 0;
            if ((int) newHeading < 0) newHeading = (Heading) 3;

            return newHeading;
        }
    }
}
