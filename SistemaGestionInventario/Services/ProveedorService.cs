using SistemaGestionInventario.Models;
using SistemaGestionInventario.Repositories;
using SistemaGestionInventario.Repositories.Interfaces;
using SistemaGestionInventario.Services.Interfaces;

namespace SistemaGestionInventario.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;
            
        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public async Task ActualizarAsync(Proveedor proveedor)
        {
            Proveedor? proveedorExistente = await _proveedorRepository
                .ObtenerPorIdAsync(proveedor.IdProveedor);

            if (proveedorExistente == null)
            {
                throw new KeyNotFoundException("El proveedor no existe.");
            }

            Proveedor? proveedorConMismoRUC = await _proveedorRepository
                .ObtenerPorRUCAsync(proveedor.RUC!);

            if (proveedorConMismoRUC != null &&
                proveedorConMismoRUC.IdProveedor != proveedor.IdProveedor)
            {
                throw new InvalidOperationException(
                    "Otro proveedor ya utiliza ese RUC.");
            }

            await _proveedorRepository.ActualizarAsync(proveedor);
        }

        public async Task CrearAsync(Proveedor proveedor)
        {

            bool existeRUC = await _proveedorRepository
                .ExisteRUCAsync(proveedor.RUC!);

            if (existeRUC)
            {
                throw new InvalidOperationException(
                    "Ya existe un proveedor con ese RUC.");
            }

            await _proveedorRepository.CrearAsync(proveedor);
        }

        public async Task EliminarAsync(int id)
        {
            Proveedor? proveedor = await _proveedorRepository
               .ObtenerPorIdAsync(id);

            if (proveedor == null)
            {
                throw new KeyNotFoundException("El proveedor no existe.");
            }

            await _proveedorRepository.EliminarAsync(proveedor);
        }

        public async Task<List<Proveedor>> ListarAsync()
        {
            return await _proveedorRepository.ListarAsync();
        }

        public async Task<Proveedor?> ObtenerPorIdAsync(int id)
        {
            return await _proveedorRepository.ObtenerPorIdAsync(id);
        }
    }
}
