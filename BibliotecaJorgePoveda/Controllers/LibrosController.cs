using AutoMapper;
using Biblioteca.Core.DTO;
using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces.Editorial;
using Biblioteca.Core.Interfaces.Libro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.UI.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IEditorialService _editorialService;
        private readonly IMapper _mapper;

        public LibrosController(ILibroService libroService, IEditorialService editorialService, IMapper mapper)
        {
            _libroService = libroService;
            _editorialService = editorialService;
            _mapper = mapper;
        }

        // GET: Libros
        public IActionResult Index()
        {
            var libros = _libroService.GetLibros();
            var librosDTO = _mapper.Map<IEnumerable<LibrosDTO>>(libros);
            return View(librosDTO);
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var libro = await _libroService.GetLibroById(id);

            if (libro == null)
            {
                return NotFound();
            }

            var libroDTO = _mapper.Map<LibrosDTO>(libro);

            return View(libroDTO);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            var editoriales = _editorialService.GetEditoriales();
            var editorialesDTO = _mapper.Map<IEnumerable<EditorialesDTO>>(editoriales);

            ViewData["IdEditorial"] = new SelectList(editorialesDTO, "Id", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEditorial,Titulo,Sinopsis,NPaginas")] LibrosDTO libroDTO)
        {
            if (ModelState.IsValid)
            {
                var libro = _mapper.Map<Libros>(libroDTO);

                await _libroService.CreateLibro(libro);
                return RedirectToAction(nameof(Index));
            }

            var editoriales = _editorialService.GetEditoriales();
            var editorialesDTO = _mapper.Map<IEnumerable<EditorialesDTO>>(editoriales);

            ViewData["IdEditorial"] = new SelectList(editorialesDTO, "Id", "Nombre", libroDTO.IdEditorial);
            return View(libroDTO);
        }

    }
}
