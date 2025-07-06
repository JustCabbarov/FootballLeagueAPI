using FluentValidation;
using FootballLeague.BLL.DTOs.Match;

namespace FootballLeague.BLL.Validations
{
    public class MatchValidation : AbstractValidator<MatchCreateDTO>
    {
        public MatchValidation()
        {
            RuleFor(x => x.HostTeamId)
                .NotEmpty().WithMessage("Home team ID is required.")
                .GreaterThan(0).WithMessage("Home team ID must be greater than 0.");
            RuleFor(x => x.GuestTeamId)
                .NotEmpty().WithMessage("Away team ID is required.")
                .GreaterThan(0).WithMessage("Away team ID must be greater than 0.");
            RuleFor(x => x.WeekNumber)
                .NotEmpty().WithMessage("Match date is required.");
            RuleFor(x => x.HostGoalCount).NotNull().WithMessage("Home team goal count is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Home team goal count must be greater than or equal to 0.");
            RuleFor(x => x.GuestGoalCount).NotNull().WithMessage("Away team goal count is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Away team goal count must be greater than or equal to 0.");
        }
    }
}
