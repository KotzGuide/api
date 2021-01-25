using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Validations
{
    public class CosmoSetValidator : AbstractValidator<CosmoSetModel>
    {
        public CosmoSetValidator()
        {
            RuleFor(x => x.Description)
                .MinimumLength(3).WithMessage("Tamanho mínimo de 5")
                .MaximumLength(75).WithMessage("Tamanho máximo de 250")
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");

            RuleFor(x => x.SaintId)
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
            RuleFor(x => x.SolarId)
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
            RuleFor(x => x.LunarId)
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
            RuleFor(x => x.StarId)
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
            RuleFor(x => x.LegendaryId)
                .NotNull().WithMessage("Esta propriedade não pode estar vazia");
        }
    }
}
