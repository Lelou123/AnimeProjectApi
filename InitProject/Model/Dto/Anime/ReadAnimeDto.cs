using InitProject.Model.Dto;
using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto.Anime;

public class ReadAnimeDto
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do anime é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do anime é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    public DateTime AnoLancamento { get; set; }

    public EpisodeDto Episode { get; set; }

    public List<CharacterDto> Characters { get; set; }
}

