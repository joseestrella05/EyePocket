using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class OrdenVenta
{
    [Key]
    public int OrdenVentaId { get; set; }

    //fk
    public int ClienteId { get; set; }
    [ForeignKey("ClienteId")]
    public Clientes? Clientes { get; set; }


    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime FechaEmision { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime FechaVencimiento { get; set; } = DateTime.Now;


    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? NumeroFactura { get; set; }

    [Required]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public double MontoTotal { get; set; }

    [Required]
    public bool Estado { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[0-9]{9}([0-9]{2})?$", ErrorMessage = "El formato del RNC no es válido.")]
    public string? RNC { get; set; }
}
