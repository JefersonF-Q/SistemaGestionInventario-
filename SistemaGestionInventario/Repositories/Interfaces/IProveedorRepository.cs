using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Repositories.Interfaces
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> ListarAsync();

        Task<Proveedor?> ObtenerPorIdAsync(int id);

        Task<Proveedor?> ObtenerPorRUCAsync(string ruc);

        Task<bool> ExisteRUCAsync(string ruc);

        Task CrearAsync(Proveedor proveedor);

        Task ActualizarAsync(Proveedor proveedor);

        Task EliminarAsync(Proveedor proveedor);
    }
}
