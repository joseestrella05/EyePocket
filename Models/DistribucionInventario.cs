using EyePocket.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DistribucionInventario
{
    [Key]
    public int DistribucionId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Productos Producto { get; set; }

    [Required(ErrorMessage = "La ubicación de la estantería es obligatoria.")]
    public string UbicacionEstanteria { get; set; }

    [Required(ErrorMessage = "La cantidad de productos en estantería es obligatoria.")]
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor o igual a 0.")]
    public int Cantidad { get; set; }

    public DateTime FechaIngreso { get; set; } = DateTime.Now;
    public string CodigoEscaneado { get; set; } = string.Empty;
}
