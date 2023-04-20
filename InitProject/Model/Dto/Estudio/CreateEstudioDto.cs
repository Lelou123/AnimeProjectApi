using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto.Estudio;

public class CreateEstudioDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public DateTime DataFundacao { get; set; }
}
