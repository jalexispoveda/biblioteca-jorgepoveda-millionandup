using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Core.DTO
{
    public class EditorialesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
        public ICollection<LibrosDTO> Libros { get; set; }
    }
}
