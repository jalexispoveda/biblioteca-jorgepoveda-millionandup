using Biblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces.Libro
{
    public interface ILibroService
    {
        IEnumerable<Libros> GetLibros();
        Task<Libros> GetLibroById(int id);
        Task CreateLibro(Libros libro);
    }
}
