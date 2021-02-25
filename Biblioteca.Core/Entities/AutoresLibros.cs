using Biblioteca.Core.Entities;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Biblioteca.Infraestructure.Data
{
    public partial class AutoresLibros
    {
        public int? IdLibros { get; set; }
        public int? IdAutor { get; set; }

        public virtual Autores IdAutorNavigation { get; set; }
        public virtual Libros IdLibrosNavigation { get; set; }
    }
}
