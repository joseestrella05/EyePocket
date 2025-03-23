using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class SolicitudesCredito
{
	[Key]
	public int SolicitudCreditoId { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int ClienteId { get; set; }
	public Clientes? Cliente { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double MontoSolicitado { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double SueldoFijo{ get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Garantia { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string DescripcionGarantia { get; set; }


	public bool EstatusDataCredito { get; set; } = true;
}
