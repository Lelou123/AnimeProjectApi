using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto;

public class ReadEpisodeDto
{
    [Required]
    public int Id { get; set; }

    [Required] 
    public int AnimeId { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public int Numero { get; set; }

    [Required]
    public int Duracao { get; set; }

    [Required]
    public AnimeDto Anime { get; set; }
}
