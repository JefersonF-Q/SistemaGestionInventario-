using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionInventario.Models
{
    public class ProductoAlmacen
    {
        public int IdProductoAlmacen { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdAlmacen { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StockActual { get; set; }

        public Producto Producto { get; set; } = null!;

        public Almacen Almacen { get; set; } = null!;

    }
}
