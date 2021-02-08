using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Validations
{
    public class SaintValidator : AbstractValidator<SaintModel>
    {
        public SaintValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage("Tamanho mínimo de 3")
                .MaximumLength(75).WithMessage("Tamanho máximo de 75")
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");

            RuleFor(x => x.Description)
                .MinimumLength(3).WithMessage("Tamanho mínimo de 3")
                .MaximumLength(500).WithMessage("Tamanho máximo de 250")
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");

            RuleFor(x => x.Rank)
                .IsInEnum().WithMessage("Rank inválido")
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
        }
    }
}
