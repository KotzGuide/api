using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Validations
{
    public class UsuarioValidator : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(3).WithMessage("Tamanho mínimo de 5")
                .MaximumLength(50).WithMessage("Tamanho máximo de 50")
                .NotNull().WithMessage("Este campo não pode ser vazio");

            RuleFor(x => x.Senha)
                .MinimumLength(3).WithMessage("Tamanho mínimo de 5")
                .MaximumLength(50).WithMessage("Tamanho máximo de 75")
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
        }
    }
}
