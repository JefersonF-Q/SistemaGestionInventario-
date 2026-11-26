using System.ComponentModel.DataAnnotations;

namespace SistemaGestionInventario.Models
{
    public class Almacen
    {
        public int IdAlmacen { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Responsable { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<ProductoAlmacen> ProductosAlmacen { get; set; } = new List<ProductoAlmacen>();
        public ICollection<Salida> Salidas { get; set; } = new List<Salida>();
        public ICollection<Transferencia> TransferenciasOrigen { get; set; } = new List<Transferencia>();
        public ICollection<Transferencia> TransferenciasDestino { get; set; } = new List<Transferencia>();
        public ICollection<MovimientoInventario> Movimientos { get; set; } = new List<MovimientoInventario>();

    }
}
