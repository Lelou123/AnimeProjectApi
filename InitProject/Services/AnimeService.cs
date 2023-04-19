using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InitProject.Services;

public class AnimeService : IAnimeService
{
    private readonly IAnimeRepository _animeRepository;
    private readonly IMapper _mapper;

    public AnimeService(IAnimeRepository animeRepository, IMapper mapper)
    {
        _animeRepository = animeRepository;
        _mapper = mapper;
    }

    public async Task< Anime> AnimeGetById(int id)
    {
        var anime = await _animeRepository.GetByIdAsync(id);

        return anime;
    }

    public async Task<PagedResponse<ReadAnimeDto>> AnimesGetAllAsync(int pageSize, int pageNumber)
    {
        var animes = await _animeRepository.GetAllAsync();

        var animesDto = _mapper.ProjectTo<ReadAnimeDto>(animes.AsQueryable()).OrderBy(x=> x.Id).ToList();


        PageDefaultValue filterRequet = new()
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = animes.Count()
        };

        var response = PageItems.GetPagedItems(animesDto, filterRequet);

        return response;
    }


    public async Task CreateAnimeAsync(Anime createAnime)
    {
        await _animeRepository.InsertAsync(createAnime);
    }



    public async Task<bool> DeleteAnimeAsync(int id)
    {
        var anime = await AnimeGetById(id);
        if(anime == null) return false;

        await _animeRepository.DeleteAsync(anime);

        return true;
    }


    public async Task<bool> PatchAsync(int id, JsonPatchDocument<Anime> patchDoc, ModelStateDictionary modelState)
    {
        var anime = await _animeRepository.GetByIdAsync(id);
        if(anime == null) return false;

        await _animeRepository.PatchAsync(anime, patchDoc, modelState);

        return true;
    }


    public async Task<bool> UpdateAnimeAsync(UpdateAnimeDto updateAnime)
    {            

        var animeQuery = await AnimeGetById(updateAnime.Id);
        if (animeQuery == null) return false;

        _mapper.Map(updateAnime, animeQuery);
        await _animeRepository.UpdateAsync(animeQuery);

        return true;
    }

}
