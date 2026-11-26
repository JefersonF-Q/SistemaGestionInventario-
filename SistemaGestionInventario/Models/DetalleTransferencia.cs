using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionInventario.Models
{
    public class DetalleTransferencia
    {
        public int IdDetalleTransferencia { get; set; }

        [Required]
        public int IdTransferencia { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Range(typeof(decimal), "0.01", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cantidad { get; set; }

        public Transferencia Transferencia { get; set; } = null!;

        public Producto Producto { get; set; } = null!;

    }
}
