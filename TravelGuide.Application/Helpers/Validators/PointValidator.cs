using FluentValidation;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Validators
{
    public class PointValidator : AbstractValidator<PointRequest>
    {
        public PointValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Название точки не должны быть пустым");
            RuleFor(p => p.Latitude)
                .InclusiveBetween(0, 180)
                .WithMessage("Широта точки должна быть больше 0 и меньше 180");
            RuleFor(p => p.Longitude)
                .InclusiveBetween(0, 180)
                .WithMessage("Долгота точки должна быть больше 0 и меньше 180");

        }
    }
}
