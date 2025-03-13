using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class Compras
{
    [Key]
    public int CompraId { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string? Estado { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string? Fecha { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public decimal Total { get; set; }

    public int ProvedorId { get; set; }

    [ForeignKey("ProvedorId")]
    public Provedores Proveedor { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = null!;
}
