using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Biblioteca.Core.Entities
{
    public partial class Libros
    {
        public int Id { get; set; }
        public int? IdEditorial { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }

        public virtual Editoriales IdEditorialNavigation { get; set; }
    }
}
