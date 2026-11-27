using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Data;
using SistemaGestionInventario.Models;
using SistemaGestionInventario.Repositories.Interfaces;

namespace SistemaGestionInventario.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task ActualizarAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task CrearAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteNombreAsync(string nombre)
        {
            return await _context.Categorias.AnyAsync(c => c.Nombre == nombre);
        }

        public async Task<List<Categoria>> ListarAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);
        }

        public async Task<Categoria?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Nombre == nombre);
        }
    }
}
