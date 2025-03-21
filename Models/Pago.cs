using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models
{
    public class Pago
    {

        [Key]

        public int PagoId { get; set; }

        public int MetodoPagoId { get; set; }

        [ForeignKey("MetodoPagoId")]
        public virtual MetodoPago MetodoPago { get; set; } = null!;

        
        public int CuentaPorPagarId { get; set; }

        [ForeignKey("CuentaPorPagarId")]
        public virtual CXP CuentaPorPagar { get; set; } = null!;

        [Required(ErrorMessage = "Favor de introducir una fecha")]
        public DateTime FechaPago { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double monto { get; set; }

    }
}
