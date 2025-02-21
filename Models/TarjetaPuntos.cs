using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class TarjetaPuntos
{ 
    [Key] 
    public int TarjetaId { get; set; }
    
    [Required]
    public string NombreCliente { get; set; }
    
    [Required]
    public string TipoTarjeta { get; set; }
    
    [Required]
    public int Puntos { get; set; } = 0;

    [Required]
    public DateTime FechaCreacion { get; set; } = DateTime.Today;
    
    [Required]
    public string Estado { get; set; }

}