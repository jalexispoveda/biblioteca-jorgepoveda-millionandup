using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces.Libro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }
        public async Task CreateLibro(Libros libro)
        {
            await _libroRepository.CreateLibro(libro);
        }

        public async Task<Libros> GetLibroById(int id)
        {
            return await _libroRepository.GetLibroById(id);
        }

        public IEnumerable<Libros> GetLibros()
        {
            return _libroRepository.GetLibros();
        }
    }
}
