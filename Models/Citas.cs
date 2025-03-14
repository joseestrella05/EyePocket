using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class Citas 
{
    public int Id { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El nombre de la persona es obligatorio")]
    public string Nombre_Persona { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El asunto de la cita es obligatorio")]
    [StringLength(200, ErrorMessage = "El asunto no puede tener más de 200 caracteres")]
    public string AsuntoCita { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El estado es obligatorio")]
    public string Estado { get; set; } = "Pendiente";
    
    [Required(ErrorMessage = "La hora es obligatoria")]
    [RegularExpression(@"^(?:[01]?[0-9]|2[0-3]):([0-5]?[0-9])\s?(AM|PM)$", ErrorMessage = "El formato de la hora es incorrecto. Ejemplo válido: 14:30")]
    public string Hora { get; set; } = string.Empty;
}