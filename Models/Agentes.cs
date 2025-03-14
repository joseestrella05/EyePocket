using System.ComponentModel.DataAnnotations;

public class Agentes
{
    [Key]
    public int AgenteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El departamento es obligatorio.")]
    public string Departamento { get; set; } = string.Empty;

    [Required(ErrorMessage = "La posición es obligatoria.")]
    public string Posicion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El salario es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El salario no puede ser negativo.")]
    public double Salario { get; set; }

    [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
    [Phone(ErrorMessage = "El número de teléfono no es válido.")]
    public string N_Telefono { get; set; } = string.Empty;
}