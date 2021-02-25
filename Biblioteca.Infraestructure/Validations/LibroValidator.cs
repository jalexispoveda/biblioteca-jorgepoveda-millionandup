using Biblioteca.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Infraestructure.Validations
{
    public class LibroValidator : AbstractValidator<LibrosDTO>
    {
        public LibroValidator()
        {
            RuleFor(libro => libro.IdEditorial)
                .NotNull();

            RuleFor(libro => libro.Titulo)
                .MaximumLength(45)
                .NotNull();

            RuleFor(libro => libro.NPaginas)
                .MaximumLength(45)
                .NotNull();

            RuleFor(libro => libro.Sinopsis)
                .NotNull();
        }
    }
}
