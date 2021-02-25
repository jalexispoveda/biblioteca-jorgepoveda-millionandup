using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces;
using Biblioteca.Core.Interfaces.Editorial;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Core.Services
{
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialService(IEditorialRepository autorRepository)
        {
            _editorialRepository = autorRepository;
        }

        public async Task CreateEditorial(Editoriales editorial)
        {
            await _editorialRepository.CreateEditorial(editorial);
        }

        public async Task<Editoriales> GetEditorialById(int id)
        {
            return await _editorialRepository.GetEditorialById(id);
        }

        public IEnumerable<Editoriales> GetEditoriales()
        {
            return _editorialRepository.GetEditoriales();
        }
    }
}
