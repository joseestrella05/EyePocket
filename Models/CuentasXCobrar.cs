using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models
{
    public class CuentasXCobrar
    {
        [Key]
        public int CXCId { get; set; }

        public int OrdenVentaId { get; set; }
        [ForeignKey("OrdenVentaId")]
        public OrdenVenta? OrdenVenta { get; set; } = new();

        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public Estados? Estados { get; set; }

        public int Periodos { get; set; }

        public double Capital { get; set; }

        public double Interes { get; set; }

        public List<CuotasCXC> ListaCuotasCXC { get; set; } = new();
	}
}
