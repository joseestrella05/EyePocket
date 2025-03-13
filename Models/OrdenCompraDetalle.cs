using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EyePocket.Models
{
    public class OrdenCompraDetalle
    {
        [Key]
        public int OdDetalleID { get; set; }

        [ForeignKey("Productos")]
        public int ProductoId { get; set; }
        public virtual Productos Productos { get; set; } = null!;


        public int OrdenCompraID { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; } = null!;

        [Required(ErrorMessage = "Introduzca una cantidad.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int cantidad { get; set; }

        public double SubTotal { get; set; }

    }
}
