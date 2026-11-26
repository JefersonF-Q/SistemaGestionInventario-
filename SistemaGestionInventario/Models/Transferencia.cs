using System.ComponentModel.DataAnnotations;

namespace SistemaGestionInventario.Models
{
    public class Transferencia
    {
        public int IdTransferencia { get; set; }

        [Required]
        public int IdAlmacenOrigen { get; set; }

        [Required]
        public int IdAlmacenDestino { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente";

        // Almacén desde donde salen los productos
        public Almacen AlmacenOrigen { get; set; } = null!;

        // Almacén que recibe los productos
        public Almacen AlmacenDestino { get; set; } = null!;

        // Productos incluidos en la transferencia
        public ICollection<DetalleTransferencia> Detalles { get; set; }
            = new List<DetalleTransferencia>();

    }
}
