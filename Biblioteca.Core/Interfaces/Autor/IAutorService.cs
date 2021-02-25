using Biblioteca.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Core.Interfaces
{
    public interface IAutorService
    {
        IEnumerable<Autores> GetAutors();

        Task CreateAutor(Autores autor);
    }
}