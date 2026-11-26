using System.ComponentModel.DataAnnotations;

namespace SistemaGestionInventario.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria")]
        [StringLength(120)]
        public string RazonSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUC es obligatorio")]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "El RUC debe tener 11 dígitos")]
        public string RUC { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El teléfono no es válido")]
        [StringLength(20)]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [StringLength(100)]
        public string? Correo { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();

    }
}
