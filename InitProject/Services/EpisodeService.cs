using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InitProject.Services;

public class EpisodeService : IEpisodeService
{
    private readonly IEpisodeRepository _episodeRepository;
    private readonly IMapper _mapper;

    public EpisodeService(IEpisodeRepository episodeRepository, IMapper mapper)
    {
        _episodeRepository = episodeRepository;
        _mapper = mapper;
    }

    public async Task CreateEpisodeAsync(Episode createEpisode)
    {
        await _episodeRepository.InsertAsync(createEpisode);
    }

    public async Task<bool> DeleteEpisodeAsync(int id)
    {
        var episode = await EpisodeGetById(id);
        if (episode == null) return false;

        await _episodeRepository.DeleteAsync(episode);

        return true;
    }

    public async Task<PagedResponse<ReadEpisodeDto>> EpisodesGetAllAsync(int pageSize, int pageNumber)
    {
        var episodes = await _episodeRepository.GetAllAsync();

        var episodeDto = _mapper.ProjectTo<ReadEpisodeDto>(episodes.AsQueryable()).OrderBy(x=> x.Id).ToList();


        PageDefaultValue filterRequet = new()
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = episodes.Count()
        };

        var response = PageItems.GetPagedItems(episodeDto, filterRequet);

        return response;
    }

    public async Task<Episode> EpisodeGetById(int id)
    {
        var episode = await _episodeRepository.GetByIdAsync(id);        
     
        return episode;
    }

    public async Task<bool> PatchEpisodeAsync(int id, JsonPatchDocument<Episode> patchDoc, ModelStateDictionary modelState)
    {
        var episode = await _episodeRepository.GetByIdAsync(id);
        if (episode == null) return false;

        await _episodeRepository.PatchAsync(episode, patchDoc, modelState);

        return true;
    }

    public async Task<bool> UpdateEpisodeAsync(UpdateEpisodeDto updateEpisode)
    {
        var episodeQuery = await EpisodeGetById(updateEpisode.Id);
        if (episodeQuery == null) return false;

        _mapper.Map(updateEpisode, episodeQuery);
        await _episodeRepository.UpdateAsync(episodeQuery);

        return true;
    }
}