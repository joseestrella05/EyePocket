using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class Compras
{
    [Key]
    public int CompraId { get; set; }

    public int EstadoId { get; set; }

    [ForeignKey("EstadoId")]
    public virtual Estados Estados { get; set; } = null!;

    public int ProvedorId { get; set; }

    [ForeignKey("ProvedorId")]
    public virtual Provedores Provedores { get; set; } = null!;

}
