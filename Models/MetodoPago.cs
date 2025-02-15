using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class MetodoPago
{
    [Key]
    public int MetodoPagoId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[\p{L}\s,]+$", ErrorMessage = "Solo se permiten letras, espacios, comas y acentos.")]
    public string? Descripcion { get; set; }
}
