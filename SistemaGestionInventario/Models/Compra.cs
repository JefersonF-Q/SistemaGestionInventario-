using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionInventario.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente";

        [Range(typeof(decimal), "0", "9999999999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public Proveedor Proveedor { get; set; } = null!;

        public ICollection<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();

    }
}
