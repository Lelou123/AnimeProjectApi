using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto.Character
{
    public class UpdateCharacterDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsAlive { get; set; }
    }
}
