using FluentValidation;
using RobotWars.Models;

namespace RobotWars.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {

            RuleFor(x => x.Arena).NotNull();
            RuleFor(x => x.Robots).NotNull();

            RuleFor(x => x).Must(BeInBounds).When(x => x.Arena != null && x.Robots != null).WithMessage("All robots must be in bounds");
        }

        private bool BeInBounds(Game game)
        {
            var robots = game.Robots;
            var width = game.Arena.Width;
            var height = game.Arena.Height;

            foreach(var robot in robots)
            {
                if (robot.Position.X < 0 || robot.Position.X > width) return false;
                if (robot.Position.Y < 0 || robot.Position.Y > height) return false;
            }

            return true;
        }

    }
}
