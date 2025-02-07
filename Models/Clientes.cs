using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyePocket.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    [Required(ErrorMessage = "El Nombres obligatorio")]
    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    [Required(ErrorMessage = "Por favor agrega una cedula o Rnc ")]
    [RegularExpression(@"^[A-Z0-9\d{2}]+$", ErrorMessage = "Solo se permiten Numero")]
    public string? Cedula { get; set; }

    [Required(ErrorMessage = "La dirrecion es obligatoria")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "El Telefono es obligatorio")]
    [RegularExpression(@"^[A-Z0-9\d{2}]+$", ErrorMessage = "Solo se permiten Numero")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime FechaIngreso { get; set; }

    [Required(ErrorMessage = "El Email es obligatorio")]
    public string? Email { get; set; }

    public int EstadoId { get; set; }

    [ForeignKey("EstadoId")]
    public virtual Estados Estados { get; set; } = null!;

}
