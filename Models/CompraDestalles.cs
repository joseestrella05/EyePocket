﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EyePocket.Models;

public class CompraDestalles
{
    [Key]
    public int DetalleId { get; set; }

    public int CompraId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Productos Productos { get; set; } = null!;

    [ForeignKey("CompraId")]
    public virtual Compras Compra { get; set; } = null!;
}
