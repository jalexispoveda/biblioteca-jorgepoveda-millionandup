using AutoMapper;
using Biblioteca.Core.DTO;
using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces.Editorial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.UI.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly IEditorialService _editorialService;
        private readonly IMapper _mapper;

        public EditorialesController(IEditorialService editorialService, IMapper mapper)
        {
            _editorialService = editorialService;
            _mapper = mapper;
        }

        // GET: Editoriales
        public IActionResult Index()
        {
            var editoriales = _editorialService.GetEditoriales();
            var editorialesDTO = _mapper.Map<IEnumerable<EditorialesDTO>>(editoriales);
            return View(editorialesDTO);
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var editorial = await _editorialService.GetEditorialById(id);
            if (editorial == null)
            {
                return NotFound();
            }

            var editorialDTO = _mapper.Map<EditorialesDTO>(editorial);
            return View(editorialDTO);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sede")] EditorialesDTO editorialDTO)
        {
            if (ModelState.IsValid)
            {
                var editorial = _mapper.Map<Editoriales>(editorialDTO);
                await _editorialService.CreateEditorial(editorial);
                return RedirectToAction(nameof(Index));
            }
            return View(editorialDTO);
        }
    }
}
