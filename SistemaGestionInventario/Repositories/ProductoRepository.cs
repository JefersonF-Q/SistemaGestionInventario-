using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Data;
using SistemaGestionInventario.Models;
using SistemaGestionInventario.Repositories.Interfaces;

namespace SistemaGestionInventario.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;
        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task CrearAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public Task EliminarAsync(Producto producto)
        {
            _context.Productos.Remove(producto);
            return _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteCodigoAsync(string codigo)
        {
            return await _context.Productos.AnyAsync(p => p.Codigo == codigo);
        }

        public Task<List<Producto>> ListarAsync()
        {
            return _context.Productos.Include(p => p.Categoria).ToListAsync();
        }

        public Task<Producto?> ObtenerPorCodigoAsync(string codigo)
        {
            return _context.Productos.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.IdProducto == id);
        }
    }
}
