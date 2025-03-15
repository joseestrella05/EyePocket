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

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no admite números ni caractereres especiales")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[RegularExpression(@"^[A-Z0-9\d{2}]+$", ErrorMessage = "Solo se permiten Numero")]
    public string? Cedula { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string? Direccion { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[RegularExpression(@"^[A-Z0-9\d{2}]+$", ErrorMessage = "Solo se permiten Numero")]
    public string? Telefono { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaIngreso { get; set; } = DateTime.Now;

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string? Email { get; set; }

    public bool Activo { get; set; }


}
