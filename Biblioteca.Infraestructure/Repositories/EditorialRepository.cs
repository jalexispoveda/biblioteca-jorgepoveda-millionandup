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
    public class EditorialRepository : IEditorialRepository
    {
        private readonly BibliotecaContext _context;

        public EditorialRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task CreateEditorial(Editoriales editorial)
        {
            await _context.Editoriales.AddAsync(editorial);
            _context.SaveChanges();
        }

        public async Task<Editoriales> GetEditorialById(int id)
        {
            return await _context.Editoriales.FindAsync(id);
        }

        public IEnumerable<Editoriales> GetEditoriales()
        {
            return _context.Editoriales.AsEnumerable();
        }
    }
}
