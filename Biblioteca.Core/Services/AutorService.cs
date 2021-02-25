using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public IEnumerable<Autores> GetAutors()
        {
            return _autorRepository.GetAuthors();
        }

        public async Task CreateAutor(Autores autor)
        {
            await _autorRepository.CreateAutor(autor);
        }
    }
}
