using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NikCore.Models
{
    public abstract class BaseModel
    {
        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; private set; }
        [NotMapped]
        [JsonIgnore]
        public List<PropertyField> Errors { get; private set; }

        protected BaseModel()
        {

        }

        protected bool Validate<Model>(Model model, AbstractValidator<Model> abstractValidator)
        {
            if (ValidationResult == null)
                ValidationResult = abstractValidator.Validate(model);

            return ValidationResult.IsValid;
        }
        
        protected bool Validate<Model>(Model model, AbstractValidator<Model> abstractValidator, ErrorContext context)
        {
            if (ValidationResult == null)
                ValidationResult = abstractValidator.Validate(model);
            if (!ValidationResult.Errors.Any())
                return true;
            var invalidFieldsList = new List<PropertyField>();

            foreach (var item in ValidationResult.Errors)
            {
                invalidFieldsList.Add(new PropertyField(item.PropertyName, item.ErrorMessage));
            }

            context.AddErrorWithFields("Campo inválido: "+model.GetType().Name.Replace("Model", ""), invalidFieldsList);

            return ValidationResult.IsValid;
        }
    }
}
