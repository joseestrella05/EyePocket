using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class CierreCaja
{
    [Key]
    public int CierreId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public double MontoApertura { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public int CantidadDeVentas { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public double MontoDeVentas { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(1, 999999, ErrorMessage = "Ingrese un número mayor que {1} y menor que {2}. ")]
    public double MontoDeCierre { get; set; }

}
