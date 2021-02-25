using Biblioteca.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Infraestructure.Validations
{
    public class EditorialValidator : AbstractValidator<EditorialesDTO>
    {
        public EditorialValidator()
        {
            RuleFor(editorial => editorial.Nombre)
                .MaximumLength(45)
                .NotNull();

            RuleFor(editorial => editorial.Sede)
                .MaximumLength(45)
                .NotNull();
        }
    }
}
