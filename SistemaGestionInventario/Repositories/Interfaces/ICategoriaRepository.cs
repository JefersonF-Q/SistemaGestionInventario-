using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListarAsync();

        Task<Categoria?> ObtenerPorIdAsync(int id);

        Task<Categoria?> ObtenerPorNombreAsync(string nombre);

        Task<bool> ExisteNombreAsync(string nombre);

        Task CrearAsync(Categoria categoria);

        Task ActualizarAsync(Categoria categoria);

        Task EliminarAsync(Categoria categoria);
    }
}
