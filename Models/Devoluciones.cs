using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EyePocket.Models;

public class Devoluciones
{
    [Key]
    public int DevolucionId { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")] 
    [StringLength(100, ErrorMessage = "El asusnto no puede exceder los 100 caracteres")] 
    public string Asunto { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha { get; set; } = DateTime.Today;
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Cliente { get; set; } = null!;
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Producto { get; set; } = null!;
    public int ProductoId { get; set; }
}