using AutoMapper;
using InitProject.Model.Dto.Estudio;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;

namespace InitProject.Services;

public class EstudioService : IEstudioService
{
    private readonly IMapper _mapper;
    private readonly IEstudioRepository _repository;
    public EstudioService(IMapper mapper, IEstudioRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task CreateEstudioAsync(Estudio createEstudio)
    {
        await _repository.InsertAsync(createEstudio);
    }

    public async Task<Estudio> EstudioGetById(int id)
    {
        var estudio = await _repository.GetByIdAsync(id);
        return estudio;
    }

    public async Task<PagedResponse<ReadEstudioDto>> EstudiosGetAllAsync(int pageSize, int pageNumber)
    {
        var estudios = await _repository.GetAllAsync();

        var estudiosDto = _mapper.ProjectTo<ReadEstudioDto>(estudios.AsQueryable()).OrderBy(x => x.Id).ToList();


        PageDefaultValue filterRequet = new()
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = estudios.Count()
        };

        var response = PageItems.GetPagedItems(estudiosDto, filterRequet);

        return response;
    }
}