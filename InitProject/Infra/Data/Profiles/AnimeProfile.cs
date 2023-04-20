using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Profiles;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<CreateAnimeDto, Anime>();
        
        CreateMap<UpdateAnimeDto, Anime>();
        
        CreateMap<Anime, UpdateAnimeDto>();

        CreateMap<Anime, ReadAnimeDto>()
             .ForMember(ep => ep.Episode, opt => opt.MapFrom(o => o.Episode))
             .ForMember(ch => ch.Characters, opt => opt.MapFrom(o => o.Characters))
             .ForMember(ea => ea.AnimeEstudio, opt => opt.MapFrom(o => o.AnimesEstudios));
        
        CreateMap<Anime, AnimeDto>();
                
    }
}
