using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionInventario.Models
{
    public class MovimientoInventario
    {
        public int IdMovimiento { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int IdAlmacen { get; set; }

        [Required]
        [StringLength(30)]
        public string TipoMovimiento { get; set; } = string.Empty;

        [Range(typeof(decimal), "0.01", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CostoUnitario { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? Referencia { get; set; }

        [StringLength(250)]
        public string? Observacion { get; set; }

        public Producto Producto { get; set; } = null!;

        public Almacen Almacen { get; set; } = null!;

    }
}
