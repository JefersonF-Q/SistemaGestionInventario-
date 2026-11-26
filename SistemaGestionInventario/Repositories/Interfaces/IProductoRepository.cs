using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> ListarAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task<Producto?> ObtenerPorCodigoAsync(string codigo);
        Task<bool> ExisteCodigoAsync(string codigo);
        Task CrearAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(Producto producto);
    }
}
