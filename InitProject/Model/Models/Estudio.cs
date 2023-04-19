using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitProject.Model.Models
{
    public class Estudio
    {
        
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<AnimeEstudio> AnimesEstudios { get; set; }
    }
}
