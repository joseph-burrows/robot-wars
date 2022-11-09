using FluentValidation;
using RobotWars.Services.Interfaces;

namespace RobotWars.Services
{
    public class ArenaBuilder : IArenaBuilder
    {
        private readonly IValidator<Arena> _arenaValidator;

        public ArenaBuilder(IValidator<Arena> arenaValidator)
        {
            _arenaValidator = arenaValidator;
        }

        public Arena Build(string input)
        {
            var split = input.Split(' ');
            var height = int.Parse(split[0]);
            var width = int.Parse(split[1]);
            var arena = new Arena { Height = height, Width = width };

            Validate(arena);

            return arena;
        }

        public void Validate(Arena arena)
        {
            var validationResult = _arenaValidator.Validate(arena);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join('\n', validationResult.Errors.Select(x => x.ErrorMessage)));
            }
        }
    }
}
