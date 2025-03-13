using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EyePocket.Models
{
    public class OrdenCompra
    {
        [Key]
        public int OrdenCompraID { get; set; }

        public int ProveedorId { get; set; }

        [ForeignKey("ProveedorId")]
        public virtual Provedores proveedores { get; set; } = null!;

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public DateTime FechaEmision { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string? NumeroFactura { get; set; }

        public DateTime FechaVencimiento { get; set; }
        public double MontoTotal { get; set; }
        public int EstadoOdId { get; set; }

        [ForeignKey("EstadoOdId")]
        public virtual EstadoOrdenCompra estadoOd { get; set; } = null!;

    
        public ICollection<OrdenCompraDetalle> OrdenCompraDetalle { get; set; } = new List<OrdenCompraDetalle>();


    }
}
