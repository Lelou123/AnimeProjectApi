using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto;

public class EstudioDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public DateTime DataFundacao { get; set; }
}
