namespace EyePocket.Models;

using System.ComponentModel.DataAnnotations;

public class Mermas
{
    [Key]
    public int MermaId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "El motivo no puede superar los 200 caracteres")]
    public string Motivo { get; set; } = string.Empty;

    [Required]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    // Relación con Producto
    public Productos? Producto { get; set; }
}
