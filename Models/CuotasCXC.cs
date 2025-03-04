using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class CuotasCXC
{
	[Key]
	public int CuotaCXCID { get; set; }


	[ForeignKey(nameof(CxC))]
	public int CXCId { get; set; }
	private CuentasXCobrar? CxC { get; set; }


	public int NumeroCuota { get; set; } = 1;


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaVencimiento { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double Interes { get; set; }
	

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double PagoCapital { get; set; }
	

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double SaldoFinal { get; set; }


	public double Mora { get; set; } = 0;


	public int EstadoId { get; set; }
	public Estados? Estado { get; set; }
}
