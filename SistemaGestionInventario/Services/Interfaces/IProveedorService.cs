using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<List<Proveedor>> ListarAsync();

        Task<Proveedor?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Proveedor proveedor);

        Task ActualizarAsync(Proveedor proveedor);

        Task EliminarAsync(int id);
    }
}
