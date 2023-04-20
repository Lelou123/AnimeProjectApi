using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InitProject.Model.Entities;
using InitProject.Model.Dto;
using InitProject.Model.Models;
using InitProject.Model.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace InitProject.Controllers;

[ApiController]
[Route("[controller]")]

public class EpisodeController : ControllerBase
{

    private IMapper _mapper;
    private readonly IEpisodeService _episodeService;

    public EpisodeController(IMapper mapper, IEpisodeService episodeService)
    {
        _mapper = mapper;
        _episodeService = episodeService;
    }


    /// <summary>
    /// Adiciona um episodio de um anime ao banco de dados
    /// </summary>
    /// <param name="episodeDto">Objeto com os campos necessários para criação de um episodio</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("CreateEpisode")]
    public async Task<IActionResult> AddEpisode([FromBody] CreateEpisodeDto episodeDto)
    {
        Episode episode = _mapper.Map<Episode>(episodeDto);

        await _episodeService.CreateEpisodeAsync(episode);

        //return CreatedAtAction(nameof(GetEpisodeById), new { episode.Id }, episodeDto);
        return Ok(episode);
    }


    /// <summary>
    /// Recuperar uma lista de episodios.
    /// </summary>
    /// <param name="pageSize">integer com a quantidade de itens por pagina</param>
    /// <param name="pageNumber">integer numero da pagina que será retornado</param>
    /// <returns>Um objeto de epiosodio</returns>
    /// <response code="201"> Caso a requisição seja feita com sucesso</response>
    [HttpGet("GetEpisodes")]
    public async Task<IActionResult> GetEpisodes([Required]int pageNumber, [Required]int pageSize)
    {
        var episode = await _episodeService.EpisodesGetAllAsync(pageSize, pageNumber);

        var response = new BaseResponseDto<PagedResponse<ReadEpisodeDto>>(true, "teste", episode);

        return Ok(response);
    }


    /// <summary>
    /// Recuperar um episodio especifico.
    /// </summary>
    /// <param name="id">integer id do episodio a ser retornado</param>
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requiisição seja feita com sucesso</response>
    [HttpGet("GetEpisode/{id}")]
    public async Task<IActionResult> GetEpisodeById(int id)
    {
        var episode = await _episodeService.EpisodeGetById(id);

        var episodeResponse = _mapper.Map<ReadEpisodeDto>(episode);
        

        var response = new BaseResponseDto<ReadEpisodeDto>(true, "Verdade", episodeResponse);


        if (episode == null) return NotFound();

        return Ok(response);
    }


    /// <summary>
    /// Atualizar todos dados um episodio especifico.
    /// </summary>
    /// <param name="id">integer id do episodio a ser alterado</param>
    /// <param name="animeDto">objeto com todos os dados a serem alterados no episodio.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204"> Caso a requisição seja feita com sucesso</response>
    [HttpPut("UpdateEpisode/{id}")]
    public async Task<IActionResult> UpdateEpisode(int id, [FromBody] UpdateEpisodeDto episodeDto)
    {
        episodeDto.Id = id;

        var isUpdated = await _episodeService.UpdateEpisodeAsync(episodeDto);

        if (!isUpdated)
            return BadRequest();

        return NoContent();
    }



    /// <summary>
    /// Deletar um episodio especifico.
    /// </summary>
    /// <param name="id">integer id do episodio a ser deletado</param>    
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requisição seja feita com sucesso</response>
    [HttpDelete("DeleteEpisode/{id}")]
    public async Task<IActionResult> DeleteEpisode(int id)
    {
        var isDeleted = await _episodeService.DeleteEpisodeAsync(id);

        if (!isDeleted) return NotFound();

        return Ok();
    }

}

