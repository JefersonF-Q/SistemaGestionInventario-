using Microsoft.AspNetCore.Mvc;
using SistemaGestionInventario.Models;
using SistemaGestionInventario.Services.Interfaces;

namespace SistemaGestionInventario.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly IProveedorService _proveedorService;

        public ProveedoresController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        // GET: Proveedores
        public async Task<IActionResult> Index()
        {
            var proveedores = await _proveedorService.ListarAsync();

            return View(proveedores);
        }

        // GET: Proveedores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var proveedor = await _proveedorService.ObtenerPorIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }

            try
            {
                await _proveedorService.CrearAsync(proveedor);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("RUC", ex.Message);

                return View(proveedor);
            }
        }

        // GET: Proveedores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var proveedor = await _proveedorService.ObtenerPorIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Proveedor proveedor)
        {
            if (id != proveedor.IdProveedor)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }

            try
            {
                await _proveedorService.ActualizarAsync(proveedor);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("RUC", ex.Message);

                return View(proveedor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Proveedores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _proveedorService.ObtenerPorIdAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _proveedorService.EliminarAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
