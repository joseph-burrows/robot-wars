using FluentValidation;

namespace RobotWars.Validators
{
    public class ArenaValidator : AbstractValidator<Arena>
    {
        public ArenaValidator()
        {
            RuleFor(x => x.Width).GreaterThan(0);
            RuleFor(x => x.Height).GreaterThan(0);
        }
    }
}
