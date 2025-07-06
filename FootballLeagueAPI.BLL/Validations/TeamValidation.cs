using FluentValidation;
using FootballLeague.BLL.DTOs.Team;

namespace FootballLeague.BLL.Validations
{
    public class TeamValidation : AbstractValidator<TeamCreateDTO>
    {
        public TeamValidation()
        {
            RuleFor(team => team.Name)
                .NotEmpty().WithMessage("Team name is required.")
                .Length(2, 50).WithMessage("Team name must be between 2 and 50 characters.");
            RuleFor(team => team.TeamCode)
                  .NotEmpty().WithMessage("Team code is required.")
                  .GreaterThan(0).WithMessage("Team code must be a positive integer.");
           
          
        }
    }
}
