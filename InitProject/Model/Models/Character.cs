using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitProject.Model.Models;

public class Character
{
    [Key]
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

    [ForeignKey("AnimeId")]
    public virtual Anime Anime { get; set; }
}