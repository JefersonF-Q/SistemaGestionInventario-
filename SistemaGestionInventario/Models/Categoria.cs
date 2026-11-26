using System.ComponentModel.DataAnnotations;

namespace SistemaGestionInventario.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(60, ErrorMessage = "El nombre no puede exceder los 60 caracteres")]
        public string? Nombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede exceder los 200 caracteres")]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
