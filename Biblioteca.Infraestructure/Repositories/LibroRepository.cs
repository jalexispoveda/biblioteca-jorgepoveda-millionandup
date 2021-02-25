using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces.Libro;
using Biblioteca.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly BibliotecaContext _context;

        public LibroRepository(BibliotecaContext context)
        {
            _context = context;
        }
        public async Task CreateLibro(Libros libro)
        {
            await _context.Libros.AddAsync(libro);
            _context.SaveChanges();
        }

        public async Task<Libros> GetLibroById(int id)
        {
            return await _context.Libros
                .Include(l => l.IdEditorialNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<Libros> GetLibros()
        {
            return _context.Libros
                .Include(x => x.IdEditorialNavigation)
                .AsEnumerable();
        }
    }
}
