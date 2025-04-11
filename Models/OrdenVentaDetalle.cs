using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models;

public class OrdenVentaDetalle
{
    [Key]
    public int DetalleId { get; set; }

    //fk
    public int OrdenVentaId { get; set; }
    [ForeignKey("OrdenVentaId")]
    public OrdenVenta? OrdenVenta { get; set; }

    public int ProductoId { get; set; }
    [ForeignKey("ProductoId")]
    public Productos? Productos { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public double Subtotal { get; set; }
}