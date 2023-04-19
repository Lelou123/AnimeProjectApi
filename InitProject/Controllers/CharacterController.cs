using AutoMapper;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Dto;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;
using Microsoft.AspNetCore.Mvc;
using InitProject.Model.Dto.Character;

namespace InitProject.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    

    private IMapper _mapper;
    private readonly ICharacterService _characterService;

    public CharacterController(IMapper mapper, ICharacterService characterService) 
    {
        _mapper = mapper;
        _characterService = characterService;
    }

    /// <summary>
    /// Adiciona um personagem ao banco de dados
    /// </summary>
    /// <param name="characterDto">Objeto com os campos necessários para criação de um personagem</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("CreateCharacter")]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddCharacter([FromBody] CreateCharacterDto characterDto)
    {
        var characterModel = _mapper.Map<Character>(characterDto);

        await _characterService.CreateCharactersAsync(characterModel);        

        var reponse = new BaseResponseDto<Character>(true, "Verdade", characterModel);

        return Ok(reponse);
    }



    /// <summary>
    /// Recuperar uma lista de personagens.
    /// </summary>
    /// <param name="pageSize">integer com a quantidade de itens por pagina</param>
    /// <param name="pageNumber">integer numero da pagina que será retornado</param>
    /// <returns>Um objeto de anime</returns>
    /// <response code="201"> Caso a requisição seja feita com sucesso</response>
    [HttpGet("GetCharacters")]
    public async Task<IActionResult> GetCharacters([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var characters = await _characterService.CharactersGetAllAsync(pageSize, pageNumber);
        

        var response = new BaseResponseDto<PagedResponse<ReadCharacterDto>>(true, "AS", characters);

        return Ok(response);
    }



    /// <summary>
    /// Recuperar um personagem especifico.
    /// </summary>
    /// <param name="id">integer id do personagem a ser retornado</param>
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requisição seja feita com sucesso</response>
    [HttpGet("GetCharacter/{id}")]
    public async Task<IActionResult> GetCharacterById(int id)
    {
        
        var character = await _characterService.CharactersGetById(id);

        var characterResult = _mapper.Map<ReadCharacterDto>(character);

        if (character is null) return NotFound();

        var response = new BaseResponseDto<ReadCharacterDto>(true, "Verdade", characterResult);

        return Ok(response);
    }



    /// <summary>
    /// Atualizar todos dados um personagem especifico.
    /// </summary>
    /// <param name="id">integer id do personagem a ser alterado</param>
    /// <param name="characterDto">objeto com todos os dados a serem alterados no personagem.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso a requisição seja feita com sucesso</response>
    [HttpPut("UpdateCharacter/{id}")]
    public async Task<IActionResult> UpdateCharacter(int id, UpdateCharacterDto characterDto)
    {
        characterDto.Id = id;

        var isUpdated = await _characterService.UpdateCharactersAsync(characterDto);

        if (!isUpdated) return BadRequest();

        return NoContent();
    }



    /// <summary>
    /// Deletar um personagem especifico.
    /// </summary>
    /// <param name="id">integer id do personagem a ser deletado</param>    
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requisição seja feita com sucesso</response>
    [HttpDelete("DeleteCharacter/{id}")]    
    public async Task<IActionResult> RemoveAnime(int id)
    {
        var deletedAnime = await _characterService.DeleteCharactersAsync(id);

        if (!deletedAnime) return NotFound();

        return Ok();
    }

}
