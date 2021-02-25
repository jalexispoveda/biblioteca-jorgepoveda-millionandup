using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Core.Entities;
using Biblioteca.Infraestructure.Data;
using Biblioteca.Core.Services;
using Biblioteca.Core.Interfaces;

namespace Biblioteca.UI.Controllers
{
    public class AutoresController : Controller
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: Autores
        public IActionResult Index()
        {
            return View(_autorService.GetAutors());
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos")] Autores autor)
        {
            if (ModelState.IsValid)
            {
                await _autorService.CreateAutor(autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }
    }
}
