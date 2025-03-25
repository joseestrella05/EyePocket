using System.ComponentModel.DataAnnotations;

namespace EyePocket.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el nombre de la categoria.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }


}
