using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models
{
    public class Deudas
    {
        [Key]
        public int DeudasId { get; set; }
  
        public double SaldoPendiente { get; set; }

        public int Periodos { get; set; }

        public float Capital { get; set; }

        public float Interes { get; set; }

        public int OrdenVentaId { get; set; }

        [ForeignKey("OrdenVentaId")]
        public OrdenVenta? OrdenVenta { get; set; }

        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public Estados? Estados { get; set; }

    }
}
