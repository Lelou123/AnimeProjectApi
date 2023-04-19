using InitProject.Model.Dto.Anime;
using InitProject.Model.Dto;
using InitProject.Model.Entities;
using InitProject.Model.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using InitProject.Model.Interfaces.Repository;

namespace InitProject.Model.Interfaces.Services;

public interface IEpisodeService
{
    Task CreateEpisodeAsync(Episode createEpisode);
    Task<PagedResponse<ReadEpisodeDto>> EpisodesGetAllAsync(int pageSize, int pageNumber);
    Task<Episode> EpisodeGetById(int id);

    Task<bool> UpdateEpisodeAsync(UpdateEpisodeDto updateEpisode);
    Task<bool> DeleteEpisodeAsync(int id);

    Task<bool> PatchEpisodeAsync(int id, JsonPatchDocument<Episode> patchDoc, ModelStateDictionary modelState);
}
