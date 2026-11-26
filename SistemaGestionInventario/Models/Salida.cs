using System.ComponentModel.DataAnnotations;

namespace SistemaGestionInventario.Models
{
    public class Salida
    {
        public int IdSalida { get; set; }

        [Required]
        public int IdAlmacen { get; set; }

        [Required]
        public DateTime FechaSalida { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El motivo es obligatorio")]
        [StringLength(150)]
        public string Motivo { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente";

        public Almacen Almacen { get; set; } = null!;

        public ICollection<DetalleSalida> Detalles { get; set; } = new List<DetalleSalida>();

    }
}
