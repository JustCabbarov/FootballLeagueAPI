using FluentValidation;
using FootballLeague.BLL.DTOs.Player;

namespace FootballLeague.BLL.Validations
{
    public class PlayerValidation : AbstractValidator<PlayerCreateDTO>
    {
        public PlayerValidation()
        {
            RuleFor(player => player.Name)
                .NotEmpty().WithMessage("Player name is required.")
                .Length(2, 50).WithMessage("Player name must be between 2 and 50 characters.");
            RuleFor(player => player.Surname)
                 .NotEmpty().WithMessage("Player surname is required.")
                 .Length(2, 50).WithMessage("Player surname must be between 2 and 50 characters.");
            RuleFor(player => player.UniformNumber)
                .GreaterThan(0).WithMessage("Uniform number must be a positive integer.")
                .LessThanOrEqualTo(99).WithMessage("Uniform number must be less than or equal to 99.");
            RuleFor(player => player.GoalCount)
                .GreaterThanOrEqualTo(0).WithMessage("Goal count cannot be negative.");
           
        }
    }
}
