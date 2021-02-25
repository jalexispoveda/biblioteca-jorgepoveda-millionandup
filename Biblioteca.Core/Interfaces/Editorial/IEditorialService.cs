using Biblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces.Editorial
{
    public interface IEditorialService
    {
        IEnumerable<Editoriales> GetEditoriales();
        Task<Editoriales> GetEditorialById(int id);
        Task CreateEditorial(Editoriales editorial);
    }
}
