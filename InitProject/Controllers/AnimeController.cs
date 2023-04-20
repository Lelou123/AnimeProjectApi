using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InitProject.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private IMapper _mapper;
    private readonly IAnimeService _animeService;

    public AnimeController(IMapper mapper, IAnimeService animeService)
    {       
        _mapper = mapper;       
        _animeService = animeService;
    }


    /// <summary>
    /// Adiciona um anime ao banco de dados
    /// </summary>
    /// <param name="animeDto">Objeto com os campos necessários para criação de um anime</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("CreateAnime")]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    public async Task <IActionResult> AddAnime([FromBody] CreateAnimeDto animeDto)
    {
        var animeModel = _mapper.Map<Anime>(animeDto);
        await _animeService.CreateAnimeAsync(animeModel);


        var reponse = new BaseResponseDto<Anime>(true, "Verdade", animeModel);

        return Ok(reponse);
    }



    /// <summary>
    /// Recuperar uma lista de animes.
    /// </summary>
    /// <param name="pageSize">integer com a quantidade de itens por pagina</param>
    /// <param name="pageNumber">integer numero da pagina que será retornado</param>
    /// <returns>Um objeto de anime</returns>
    /// <response code="201"> Caso a requisição seja feita com sucesso</response>
    [HttpGet("GetAnimes")]
    public async Task<IActionResult> GetAnimes([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var anime =  await _animeService.AnimesGetAllAsync(pageSize, pageNumber);

        var response = new BaseResponseDto<PagedResponse<ReadAnimeDto>>(true, "AS", anime);

        return Ok(response);
    }



    /// <summary>
    /// Recuperar um anime especifico.
    /// </summary>
    /// <param name="id">integer id do anime a ser retornado</param>
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requiisição seja feita com sucesso</response>
    [HttpGet("GetAnime/{id}")]
    public async Task< IActionResult> GetAnimeById(int id)
    {
        var anime = await _animeService.AnimeGetById(id);

        var animeResponse = _mapper.Map<ReadAnimeDto>(anime);

        if (anime is null) return NotFound();

        var response = new BaseResponseDto<ReadAnimeDto>(true, "Verdade", animeResponse);

        return Ok(response);
    }



    /// <summary>
    /// Atualizar todos dados um anime especifico.
    /// </summary>
    /// <param name="id">integer id do anime a ser alterado</param>
    /// <param name="animeDto">objeto com todos os dados a serem alterados no anime.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso a requisição seja feita com sucesso</response>
    [HttpPut("UpdateAnime/{id}")]
    public async Task<IActionResult> UpdateAnime(int id, UpdateAnimeDto animeDto)
    {
        animeDto.Id = id;

        var isUpdated = await _animeService.UpdateAnimeAsync(animeDto);
        
        if (!isUpdated)
            return BadRequest();

        return NoContent();
    }



    /// <summary>
    /// Atualizar um dado especifico de um anime.
    /// </summary>
    /// <param name="id">integer id do anime a ser alterado</param>
    /// <param name="patch">objeto com os dados especificos a serem alterados no anime.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso a requisição seja feita com sucesso</response>
    [HttpPatch("UpdatePatchAnime/{id}")]
    public async Task< IActionResult> UpdatePatchAnime(int id, JsonPatchDocument<Anime> patch)
    {
        
        var updateAnime = await _animeService.PatchAsync(id, patch, ModelState);
        if (!updateAnime) BadRequest();

        return NoContent();
    }



    /// <summary>
    /// Deletar um anime especifico.
    /// </summary>
    /// <param name="id">integer id do anime a ser deletado</param>    
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requisição seja feita com sucesso</response>
    [HttpDelete("DeleteAnime/{id}")]
    public async Task<IActionResult> RemoveAnime(int id)
    {

        var deletedAnime = await _animeService.DeleteAnimeAsync(id);
        if (!deletedAnime) return NotFound();

        return Ok();
    }
}
