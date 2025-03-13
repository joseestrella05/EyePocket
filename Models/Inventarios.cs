using System.ComponentModel.DataAnnotations;
using EyePocket.Models;

public class Inventarios
{
    [Key]
    public int InventarioId { get; set; }
    public int ProductoId { get; set; }
    public Productos Producto { get; set; }
    public int Stock { get; set; }
    public int Entradas { get; set; }
    public int Salidas { get; set; }
   
    public double importe { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public List<Mermas> Mermas { get; set; } = new List<Mermas>();
}

