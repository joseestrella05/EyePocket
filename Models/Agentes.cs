using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class Agentes
{
    
    [Key]
    public int AgenteId { get; set; }
    
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numeros")]
    [Required(ErrorMessage = "El Nombre es obligatorio")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El correo es obligatorio")]
    public string Correo { get; set; }
    
    [Required(ErrorMessage = "El departamento es obligatorio")]
    public string Departamento { get; set; }
    
    [Required(ErrorMessage = "El Telefono es obligatorio")]
    [RegularExpression(@"^[A-Z0-9\d{2}]+$", ErrorMessage = "Solo se permiten numeros")]
    public string? Telefono { get; set; }
    
    [Required]
    public int cantidadTickets { get; set; }
}