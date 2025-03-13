using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class MetodosPago
{
	[Key]
	public int MetodoPagoId { get; set; }

	public string Descripcion { get; set; } = string.Empty;
}
