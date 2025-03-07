using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class EstadoCXP
{
    [Key]
    public int EstadoCXPId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    public string? descripcion { get; set; }
}
