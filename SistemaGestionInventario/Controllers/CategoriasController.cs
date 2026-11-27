using Microsoft.AspNetCore.Mvc;
using SistemaGestionInventario.Models;
using SistemaGestionInventario.Services.Interfaces;

namespace SistemaGestionInventario.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ListarAsync();

            return View(categorias);
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaService.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            try
            {
                await _categoriaService.CrearAsync(categoria);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Nombre", ex.Message);

                return View(categoria);
            }
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            try
            {
                await _categoriaService.ActualizarAsync(categoria);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Nombre", ex.Message);

                return View(categoria);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _categoriaService.EliminarAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
