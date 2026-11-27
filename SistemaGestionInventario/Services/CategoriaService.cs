using SistemaGestionInventario.Models;
using SistemaGestionInventario.Repositories.Interfaces;
using SistemaGestionInventario.Services.Interfaces;

namespace SistemaGestionInventario.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task ActualizarAsync(Categoria categoria)
        {
            Categoria? categoriaExistente = await _categoriaRepository
                .ObtenerPorIdAsync(categoria.IdCategoria);

            if (categoriaExistente == null)
            {
                throw new KeyNotFoundException("La categoría no existe.");
            }

            Categoria? categoriaConMismoNombre = await _categoriaRepository
                .ObtenerPorNombreAsync(categoria.Nombre!);

            if (categoriaConMismoNombre != null &&
                categoriaConMismoNombre.IdCategoria != categoria.IdCategoria)
            {
                throw new InvalidOperationException(
                    "Otra categoría ya utiliza ese nombre.");
            }

            await _categoriaRepository.ActualizarAsync(categoria);
        }

        public async Task CrearAsync(Categoria categoria)
        {
            bool existeNombre = await _categoriaRepository.ExisteNombreAsync(categoria.Nombre!);
            if (existeNombre)
            {
                throw new InvalidOperationException("Ya existe una categoría con ese nombre.");
            }
            await _categoriaRepository.CrearAsync(categoria);
        }      
        public async Task EliminarAsync(int id)
        {
            Categoria? categoria = await _categoriaRepository.ObtenerPorIdAsync(id);
            if(categoria == null)
            {
                throw new InvalidOperationException("La categoría no existe.");
            }
            await _categoriaRepository.EliminarAsync(categoria);
        }

        public async Task<List<Categoria>> ListarAsync()
        {
           return await _categoriaRepository.ListarAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _categoriaRepository.ObtenerPorIdAsync(id);
        }
    }
}
