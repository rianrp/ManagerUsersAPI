using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(){
            RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade não pode ser vazia. ")
            .NotNull()
            .WithMessage("A entidade não pode ser nula. ");

            RuleFor(x => x.name)
            .NotNull()
            .WithMessage("A entidade não pode ser vazia. ")
            .NotEmpty()
            .WithMessage("A entidade não pode ser vazia. ")

            .MinimumLength(3)
            .WithMessage("O nome deve ter no mínimo 3 carácteres. ")
            .MaximumLength(100)
            .WithMessage("O nome deve ter no máximo 100 caracteres. ");

            RuleFor(x => x.password)
            .NotNull()
            .WithMessage("A senha não pode ser vazia. ")
            .NotEmpty()
            .WithMessage("A senha não pode ser vazia. ")

            .MinimumLength(3)
            .WithMessage("O senha deve ter no mínimo 3 carácteres. ")
            .MaximumLength(100)
            .WithMessage("O senha deve ter no máximo 100 caracteres. ");

            RuleFor(x => x.email)
            .NotNull()
            .WithMessage("O Email não pode ser nulo. ")
            .NotEmpty()
            .WithMessage("O Email não pode ser vazio ")
            .MinimumLength(10)
            .WithMessage("O email deve ter no mínimo 10 caracteres. ")
            .MaximumLength(180)
            .WithMessage("O email deve ter no máximo 180 caracteres. ")
            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("O Email informado não é válido");
        }
    }
}