using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class Compras
{
    [Key]
    public int CompraId { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string? Estado { get; set; }
}
