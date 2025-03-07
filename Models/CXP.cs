using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class CXP
{
    [Key]

    public int CuentaId { get; set; }
    public int FacturaId { get; set; }
    public int EstadoCXPId { get; set; }

    [ForeignKey("EstadoCXPId")]
    public virtual EstadoCXP EstadoCXP { get; set; } = null!;

    [Required(ErrorMessage = "Por favor agregue el saldo pendiente")]
    public decimal SaldoPendiente { get; set; }

    [Required(ErrorMessage = "Por favor agregue el valor del ultimo pago")]
    public decimal UltimoPago { get; set; }

    [Required(ErrorMessage = "Por favor agregue el estado de la cuenta")]

    public int MetodoPagoId { get; set; }

    [ForeignKey("MetodoPagoId")]
    public virtual MetodoPago MetodoPago { get; set; } = null!;
}
