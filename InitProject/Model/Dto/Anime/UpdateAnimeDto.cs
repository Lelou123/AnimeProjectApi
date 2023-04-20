using System.ComponentModel.DataAnnotations;

namespace InitProject.Model.Dto;

public class UpdateAnimeDto
{
    
    [Required(ErrorMessage = "O título do anime é obrigatório")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "O gênero do anime é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    
    [Required]
    public DateTime AnoLancamento { get; set; }
   
    public int Id { get; set; }

}
