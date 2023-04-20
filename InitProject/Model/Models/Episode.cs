using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Models;

public class Episode
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O titulo do straming é obrigatório")]
    public string Titulo { get; set; }

    public int Numero { get; set; }

    public int Duracao { get; set; }

    public int AnimeId { get; set; }

    public virtual Anime Anime { get; set; }
}
