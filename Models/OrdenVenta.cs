using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class OrdenVenta
{
    [Key]
    public int OrdenVentaId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime FechaEmision { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? NumeroFactura { get;set; }

    [Required]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public double MontoTotal { get; set; }

    [Required]
    public bool Estado { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? NFC {  get; set; }

    //fk
    public int ClienteId { get; set; }
    [ForeignKey("ClienteId")]
    public Clientes? Clientes { get; set; }
}
