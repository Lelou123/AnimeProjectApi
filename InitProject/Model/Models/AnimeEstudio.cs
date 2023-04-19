using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitProject.Model.Models
{
    public class AnimeEstudio
    {        
        public int? EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        public virtual Estudio Estudio { get; set; }

        public int? AnimeId { get; set; }

        [ForeignKey("AnimeId")]
        public virtual Anime Anime { get; set; }
    }
}
