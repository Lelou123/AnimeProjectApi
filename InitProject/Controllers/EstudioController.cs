using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;
using Microsoft.AspNetCore.Mvc;
using InitProject.Model.Dto.Estudio;

namespace InitProject.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudioController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEstudioService _service;

    public EstudioController(IMapper mapper, IEstudioService service)
    {
        _mapper = mapper;
        _service = service;
    }


    /// <summary>
    /// Adiciona um estudio ao banco de dados
    /// </summary>
    /// <param name="estudioDto">Objeto com os campos necessários para criação de um estudio</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("CreateEstudio")]        
    public async Task<IActionResult> AddEstudio([FromBody] CreateEstudioDto estudioDto)
    {
        var estudioModel = _mapper.Map<Estudio>(estudioDto);        
        await _service.CreateEstudioAsync(estudioModel);


        var reponse = new BaseResponseDto<Estudio>(true, "Verdade", estudioModel);

        return Ok(reponse);
    }   



    /// <summary>
    /// Recuperar uma lista de estudios.
    /// </summary>
    /// <param name="pageSize">integer com a quantidade de itens por pagina</param>
    /// <param name="pageNumber">integer numero da pagina que será retornado</param>
    /// <returns>Um objeto de estudio</returns>
    /// <response code="201"> Caso a requisição seja feita com sucesso</response>
    [HttpGet("GetEstudios")]
    public async Task<IActionResult> GetAnimes([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        var estudios = await _service.EstudiosGetAllAsync(pageSize, pageNumber);

        var response = new BaseResponseDto<PagedResponse<ReadEstudioDto>>(true, "AS", estudios);

        return Ok(response);
    }


    /// <summary>
    /// Recuperar um estudio especifico.
    /// </summary>
    /// <param name="id">integer id do estudio a ser retornado</param>
    /// <returns>IActionResult</returns>
    /// <response code="200"> Caso a requiisição seja feita com sucesso</response>
    [HttpGet("GetEstudio/{id}")]
    public async Task<IActionResult> GetAnimeById(int id)
    {
        var estudio = await _service.EstudioGetById(id);

        if (estudio is null) return NotFound();

        var estudioReponse = _mapper.Map<ReadEstudioDto>(estudio);
        
        var response = new BaseResponseDto<ReadEstudioDto>(true, "Verdade", estudioReponse);

        return Ok(response);
    }
}
