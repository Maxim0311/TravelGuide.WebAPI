using FluentValidation;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Validators
{
    public class AuthRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthRequestValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Логин не должен быть пустым")
                .MinimumLength(5)
                .WithMessage("Логин должен содержать хотя бы 5 символов");
            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Пароль не должен быть пустым")
                .MinimumLength(6)
                .WithMessage("Пароль должен содержать хотя бы 6 символов");
        }
    }
}
