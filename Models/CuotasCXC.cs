using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class CuotasCXC
{
	[Key]
	public int CuotaCXCID { get; set; }


	[ForeignKey("CXCId")]
	public int CXCId { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaVencimiento { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double MontoCuota { get; set; }


	public int EstadoId { get; set; }
	public Estados? Estado { get; set; }
}
