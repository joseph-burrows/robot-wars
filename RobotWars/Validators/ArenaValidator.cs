using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
