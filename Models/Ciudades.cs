using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class Ciudades
{
    [Key] public int CiudadId { get; set; }
   
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
    [StringLength(maximumLength: 40, ErrorMessage = "El nombre no debe exceder los 40 caracteres")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public string CiudadNombre { get; set; } = null!;
    public int ClienteId { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Cliente { get; set; } = null!;
}