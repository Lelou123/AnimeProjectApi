using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Models;

public class Anime
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do anime é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do anime é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    public DateTime AnoLancamento { get; set; }

    public virtual Episode Episode { get; set; }
    public virtual ICollection<Character> Characters { get; set; }

    public virtual ICollection<Estudio>Estudios { get; set; }
    public virtual ICollection<AnimeEstudio> AnimesEstudios { get; set; }

}
