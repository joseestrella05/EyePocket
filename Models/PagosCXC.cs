using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class PagosCXC
{
	[Key]
	public int Id { get; set; }


	[ForeignKey(nameof(Deuda))]
	public int CXCId { get; set; }

	public CuentasXCobrar? Deuda { get; set; }


	public string? Descripcion { get; set; }


	public DateTime FechaPago { get; set; } = DateTime.Now;

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int MetodoPagoId { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double MontoPagado { get; set; }
}
