using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto.Estudio;

public class ReadEstudioDto
{

    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public DateTime DataFundacao { get; set; }

    public List<AnimeEstudioDto> AnimeEstudio { get; set; }
}
