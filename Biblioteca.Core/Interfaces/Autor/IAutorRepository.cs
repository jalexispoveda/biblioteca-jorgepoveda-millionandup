using Biblioteca.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces
{
    public interface IAutorRepository
    {
        IEnumerable<Autores> GetAuthors();
        Task<Autores> GetAuthor(int id);
        Task CreateAutor(Autores autor);
        void UpdateAutor(int id, Autores autor);
    }
}
