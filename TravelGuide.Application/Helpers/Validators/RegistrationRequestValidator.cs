using FluentValidation;
using TravelGuide.Domain.Models;

namespace TravelGuide.Application.Helpers.Validators
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Логин не должен быть пустым")
                .MinimumLength(5)
                .WithMessage("Логин должен содержать хотя бы 5 символов");
            RuleFor(r => r.FirstName)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым");
            RuleFor(r => r.LastName)
                .NotEmpty()
                .WithMessage("Фамилия не должна быть пустой");
            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Пароль не должен быть пустым")
                .MinimumLength(6)
                .WithMessage("Пароль должен содержать хотя бы 6 символов")
                .Equal(r => r.PasswordConfirm)
                .WithMessage("Пароли не совпадают");
        }
    }
}
