using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionInventario.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(30)]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioCompra { get; set; }

        [Range(typeof(decimal), "0", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }

        [Range(0, int.MaxValue)]
        public int StockMinimo { get; set; }

        public bool Activo { get; set; } = true;

        public Categoria Categoria { get; set; } = null!;

        public ICollection<ProductoAlmacen> ProductosAlmacen { get; set; } = new List<ProductoAlmacen>();
        public ICollection<DetalleCompra> DetallesCompra { get; set; } = new List<DetalleCompra>();
        public ICollection<DetalleSalida> DetallesSalida { get; set; } = new List<DetalleSalida>();
        public ICollection<DetalleTransferencia> DetallesTransferencia { get; set; } = new List<DetalleTransferencia>();
        public ICollection<MovimientoInventario> Movimientos { get; set; } = new List<MovimientoInventario>();


    }
}
