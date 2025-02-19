using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O Nome não pode esta vazio");

            RuleFor(request => request.Email).EmailAddress().WithMessage("O e-mail não é valido");

            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatória.");

            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha é obrigatória.");
            });
        }

        
    }
}
