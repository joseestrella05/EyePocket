using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }
    
    public int ClienteId { get; set; }
    
    public int AgenteId { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    public string Asunto { get; set; }
    [Required(ErrorMessage = "El campo es requerido")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    public string Estado { get; set; } = "Recibido";
    
    [Required(ErrorMessage = "El campo es requerido")]
    public string Prioridad { get; set; }
    
    
    [Required]
    public DateTime Fecha { get; set; } = DateTime.Today;
    
    [ForeignKey("AgenteId")]
    public Agentes Agente { get; set; }
    [ForeignKey("ClienteId")]
    public Clientes Cliente { get; set; }
}