﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Core.Entities
{
    public class Editoriales
    {
        public Editoriales()
        {
            Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
