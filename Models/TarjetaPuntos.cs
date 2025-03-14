using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class TarjetaPuntos
{ 
    [Key] 
    public int TarjetaId { get; set; }

    [Required]
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes Cliente { get; set; } = null!;
    
    [Required]
    public string TipoTarjeta { get; set; }

    [Required]
    public int Puntos { get; set; } = 0;
    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.Today;
    
    [Required]
    public string Estado { get; set; }
}