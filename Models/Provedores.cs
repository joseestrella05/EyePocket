using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class Provedores
{
    [Key]
    public int ProvedorId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "El nombre no puede contener números")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "La dirrecion es obligatorio")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "El telefono es obligatorio")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "El telefono debe contener 10 números")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo no es valido")]
    public string? Correo { get; set; }
}
