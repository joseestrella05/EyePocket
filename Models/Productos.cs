﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El costo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a 0.")]
        public double Costo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public string? Categoria { get; set; }

        public string? Proveedor { get; set; }
        [Required(ErrorMessage ="Describa el producto")]
        public string? Descripcion { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100.")]
        public decimal Descuento { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; }
    }
}
