using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionInventario.Models
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }

        [Required]
        public int IdCompra { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Range(typeof(decimal), "0.01", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cantidad { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostoUnitario { get; set; }

        public Compra Compra { get; set; } = null!;

        public Producto Producto { get; set; } = null!;

    }
}
