using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto;
public class CreateEpisodeDto
{
    [Required]
    public int AnimeId { get; set; }

    [Required (ErrorMessage = "O titulo do episodio é obrigatório")]
    public string Titulo { get; set; }

    [Required]
    public int Numero { get; set; }
    
    [Required]
    public int Duracao { get; set; }

}
