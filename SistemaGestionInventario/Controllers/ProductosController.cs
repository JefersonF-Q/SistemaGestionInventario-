using Microsoft.AspNetCore.Mvc;
using SistemaGestionInventario.Models;
using SistemaGestionInventario.Services.Interfaces;

namespace SistemaGestionInventario.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.ListarAsync();

            return View(productos);
        }

        // GET: Productos/Details/
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            try
            {
                await _productoService.CrearAsync(producto);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Codigo", ex.Message);

                return View(producto);
            }
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            try
            {
                await _productoService.ActualizarAsync(producto);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Codigo", ex.Message);

                return View(producto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoService.ObtenerPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productoService.EliminarAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
