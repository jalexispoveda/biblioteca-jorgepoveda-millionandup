using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces;
using Biblioteca.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaContext _context;

        public AutorRepository(BibliotecaContext context)
        {
            _context = context;
        }
        public async Task CreateAutor(Autores autor)
        {
            await _context.Autores.AddAsync(autor);
            _context.SaveChanges();
        }

        public async Task<Autores> GetAuthor(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public IEnumerable<Autores> GetAuthors()
        {
            return _context.Autores.AsEnumerable();
        }

        public void UpdateAutor(int id, Autores autor)
        {
            throw new NotImplementedException();
        }
    }
}
