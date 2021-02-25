using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces.Libro;
using Biblioteca.Infraestructure.Data;
using Biblioteca.Infraestructure.Repositories;
using Biblioteca.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.UnitTests.Libross
{
    public class LibrosTests
    {
        //Create In Memory Database


        [Test]
        public async Task GetLibroById_InMemoryBD()
        {

            var options = new DbContextOptionsBuilder<BibliotecaContext>()
            .UseInMemoryDatabase(databaseName: "Biblioteca")
            .Options;

            using (var context = new BibliotecaContext(options))
            {
                var libroTest = new Libros()
                {
                    Id = 444444,
                    IdEditorial = 1,
                    Titulo = "Libro1",
                    Sinopsis = "Sinopsis prueba",
                    NPaginas = "100"

                };

                context.Libros.Add(libroTest);
                context.SaveChanges();
            }


            using (var context = new BibliotecaContext(options))
            {
                ILibroRepository libroRepository = new LibroRepository(context);
                var libro = await libroRepository.GetLibroById(444444);

                Assert.AreEqual("Libro1", libro.Titulo);
                Assert.AreEqual("Sinopsis prueba", libro.Sinopsis);
                Assert.AreEqual("100", libro.NPaginas);
            }
        }
    }
}
