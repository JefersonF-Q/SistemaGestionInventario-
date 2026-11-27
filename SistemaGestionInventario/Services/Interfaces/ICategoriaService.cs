using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> ListarAsync();
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Categoria categoria);
        Task ActualizarAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}
