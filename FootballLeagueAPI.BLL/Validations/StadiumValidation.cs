using FluentValidation;
using FootballLeague.BLL.DTOs.Stadium;

namespace FootballLeague.BLL.Validations
{
    public class StadiumValidation : AbstractValidator<StadiumCreateDTO>
    {
        public StadiumValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Stadium name cannot be empty.")
                .Length(3, 100).WithMessage("Stadium name must be between 3 and 100 characters.");
            RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Stadium capacity must be greater than zero.");
            
        }
    }
}
