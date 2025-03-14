using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El costo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a 0.")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una provedor.")]
    
        public int ProveedorId { get; set; }
        [ForeignKey("ProveedorId")]
        public Provedores? Proveedor { get; set; }

        [Required(ErrorMessage ="Describa el producto")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}
