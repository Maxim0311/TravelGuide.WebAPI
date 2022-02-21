using FluentValidation;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Validators
{
    public class RouteValidator : AbstractValidator<RouteRequest>
    {
        public RouteValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .WithMessage("Название маршрута не должно быть пустым");
            RuleFor(r => r.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Маршрут должен содержать id создателя");
            RuleFor(r => r.Points)
                .Must(value => value.Count > 0)
                .WithMessage("Маршрут должен содержать хотя бы 1 точку");
            RuleForEach(r => r.Points)
                .SetValidator(new PointValidator());
        }
    }
}
