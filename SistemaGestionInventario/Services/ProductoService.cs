using SistemaGestionInventario.Models;
using SistemaGestionInventario.Repositories;
using SistemaGestionInventario.Repositories.Interfaces;
using SistemaGestionInventario.Services.Interfaces;

namespace SistemaGestionInventario.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task ActualizarAsync(Producto producto)
        {
            Producto? productoExistente = await _productoRepository.ObtenerPorIdAsync(producto.IdProducto);

            if (productoExistente == null)
            {
                throw new KeyNotFoundException("El producto no existe.");
            }

            Producto? productoConMismoCodigo = await _productoRepository
                .ObtenerPorCodigoAsync(producto.Codigo);

            if (productoConMismoCodigo != null &&
                productoConMismoCodigo.IdProducto != producto.IdProducto)
            {
                throw new InvalidOperationException(
                    "Otro producto ya utiliza ese código.");
            }

            await _productoRepository.ActualizarAsync(producto);
        }

        public async Task CrearAsync(Producto producto)
        {
            bool existeCodigo = await _productoRepository.ExisteCodigoAsync(producto.Codigo);
            if (existeCodigo)
            {
                throw new InvalidOperationException("Ya existe un producto con este codigo");
            }
            await _productoRepository.CrearAsync(producto);
        }

        public async Task EliminarAsync(int id)
        {
            Producto? producto = await _productoRepository
                .ObtenerPorIdAsync(id);

            if (producto == null)
            {
                throw new KeyNotFoundException("El producto no existe.");
            }

            await _productoRepository.EliminarAsync(producto);
        }

        public async Task<List<Producto>> ListarAsync()
        {
            return await _productoRepository.ListarAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerPorIdAsync(id);
        }
    }
}
