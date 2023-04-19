using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto
{
    public class CharacterDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsAlive { get; set; }

        [Required]
        public int AnimeId { get; set; }
    }
}
