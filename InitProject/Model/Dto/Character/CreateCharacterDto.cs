using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto.Character;

public class CreateCharacterDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public bool IsAlive { get; set; }

    [Required]
    public int AnimeId { get; set; }
}
