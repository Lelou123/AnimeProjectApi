﻿using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Models;

public class Estudio
{
    
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }
    [Required]
    public DateTime DataFundacao { get; set; }

    public virtual ICollection<AnimeEstudio> AnimesEstudios { get; set; }
}
