using FluentValidation;

namespace RobotWars.Validators
{
    public class RobotValidator : AbstractValidator<Robot>
    {
        public RobotValidator()
        {
            RuleFor(x => x.Heading).NotNull();
            RuleFor(x => x.Commands).NotNull();
            RuleFor(x => x.Position).NotNull();
        }
    }
}
