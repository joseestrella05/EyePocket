using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class PagosCXC
{
	[Key]
	public int Id { get; set; }


	[ForeignKey("DeudaId")]
	public int CXCId { get; set; }
	public Deudas Deuda { get; set; } = null!;


	public string? Descripcion { get; set; }


	public DateTime FechaPago { get; set; } = DateTime.Now;


	public int MetodoPagoId { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]


	public double MontoPagado { get; set; }
}
