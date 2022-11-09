using FluentValidation;
using RobotWars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Validators
{
    public class RobotValidator : AbstractValidator<Robot>
    {
        public RobotValidator()
        {
            RuleFor(x => x.Heading).NotNull();
            RuleFor(x => x.Commands).NotNull();
            RuleFor(x => x.Commands).Must(BeAValidCommandList);
            RuleFor(x => x.Position).NotNull();
        }
        private bool BeAValidCommandList(IEnumerable<Command> commands)
        {
            if (commands.Count(x => x == null) >= 1) return false;

            return true;
        }
    }
}
