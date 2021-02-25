using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Core.DTO
{
    public class LibrosDTO
    {
        public int Id { get; set; }
        public int? IdEditorial { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public EditorialesDTO IdEditorialNavigation { get; set; }
    }
}
