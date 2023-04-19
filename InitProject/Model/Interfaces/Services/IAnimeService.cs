using InitProject.Model.Dto;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Entities;
using InitProject.Model.Models;
using MathNet.Numerics.Statistics.Mcmc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InitProject.Model.Interfaces.Services;

public interface IAnimeService
{
    Task CreateAnimeAsync(Anime createAnime);
    Task<PagedResponse<ReadAnimeDto>> AnimesGetAllAsync(int pageSize, int pageNumber);
    Task<Anime> AnimeGetById(int id);

    Task<bool> UpdateAnimeAsync(UpdateAnimeDto updateAnime);
    Task<bool> DeleteAnimeAsync(int id);

    Task<bool> PatchAsync(int id, JsonPatchDocument<Anime> patchDoc, ModelStateDictionary modelState);
}
