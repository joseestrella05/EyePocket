using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; 

namespace EyePocket.Models
{
    public class EstadoOrdenCompra
    {
        [Key]

        public int EstadoOdId { get; set; }
        public string? descripcionEstado { get; set; }


    }
}
