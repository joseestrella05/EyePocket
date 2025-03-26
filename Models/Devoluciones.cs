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
    
    public DateTime Fecha { get; set; } = DateTime.Today;
    
    [ForeignKey("ClienteId")] 
    public Clientes Cliente { get; set; } = null!;
    
    [ForeignKey("ProductoId")]
    public Productos Producto { get; set; } = null!;
}