using FluentValidation;
using AvanadeEstudosAPI.Domain.Entities;
using System.Text.RegularExpressions;

namespace AvanadeEstudosAPI.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nula.")

                .NotEmpty()
                .WithMessage("A senha não pode ser vazia.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MaximumLength(30)
                .WithMessage("A senha deve ter no máximo 30 caracteres.");

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("Informe a senha")

               .Length(6, 20)
               .WithMessage("Senha deve ter no mínimo 6 e no máximo 20 caractéres")

               .Must(RequireDigit)
               .WithMessage("Senha deve ter pelo menos 1 número")

               .Must(RequiredLowerCase)
               .WithMessage("Senha deve ter pelo menos 1 caracter minúsculo")

               .Must(RequireUppercase)
               .WithMessage("Senha deve ter pelo menos 1 caracter maiúsculo")

               .Must(RequireNonAlphanumeric)
               .WithMessage("Digite pelo menos 1 caracter especial (@ ! & * ...)");
        }

        private bool RequireDigit(string password)
        {
            if (password.Any(x => char.IsDigit(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequiredLowerCase(string password)
        {
            if (password.Any(x => char.IsLower(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireUppercase(string password)
        {
            if (password.Any(x => char.IsUpper(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireNonAlphanumeric(string password)
        {

            if (Regex.IsMatch(password, "(?=.*[@#$%^&+=])"))
            {
                return true;
            }
            return false;
        }
    }
}