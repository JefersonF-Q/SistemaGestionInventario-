using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Data;
using SistemaGestionInventario.Models;
using SistemaGestionInventario.Repositories.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace SistemaGestionInventario.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly AppDbContext _context;
        public ProveedorRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task ActualizarAsync(Proveedor proveedor)
        {
             _context.Proveedores.Update(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task CrearAsync(Proveedor proveedor)
        {
            await _context.Proveedores.AddAsync(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Proveedor proveedor)
        {
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteRUCAsync(string ruc)
        {
            return await _context.Proveedores.AnyAsync(p => p.RUC == ruc);
        }

        public async Task<List<Proveedor>> ListarAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor?> ObtenerPorIdAsync(int id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.IdProveedor == id);
        }

        public async Task<Proveedor?> ObtenerPorRUCAsync(string ruc)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.RUC == ruc);
        }
    }
}
