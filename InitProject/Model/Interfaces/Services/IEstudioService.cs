using InitProject.Model.Dto.Estudio;
using InitProject.Model.Entities;
using InitProject.Model.Models;

namespace InitProject.Model.Interfaces.Services;

public interface IEstudioService
{
    Task CreateEstudioAsync(Estudio createEstudio);
    Task<PagedResponse<ReadEstudioDto>> EstudiosGetAllAsync(int pageSize, int pageNumber);
    Task<Estudio> EstudioGetById(int id);
}
