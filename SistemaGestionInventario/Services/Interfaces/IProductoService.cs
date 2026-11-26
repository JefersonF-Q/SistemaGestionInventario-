using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> ListarAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
