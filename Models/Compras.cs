using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class Compras
{
    [Key]
    public int CompraId { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Campo obrigatório")]
    public decimal Total { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string? Descripcion { get; set; }
    public int EstadoId { get; set; }

    [ForeignKey("EstadoId")]
    public Estados Estado { get; set; } = null!;

    public int ProvedorId { get; set; }

    [ForeignKey("ProvedorId")]
    public Provedores Proveedor { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = null!;

    public virtual ICollection<ComprasDetalles> ComprasDetalles { get; set; } = null!;
}
