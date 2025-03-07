using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class MetodoPago
{
    [Key]

    public int MetodoPagoId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    public string? Descripcion { get; set; }

}
