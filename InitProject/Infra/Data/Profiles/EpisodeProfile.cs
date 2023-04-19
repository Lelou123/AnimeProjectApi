using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Models;
using InitProject.Model.Dto;

namespace InitProject.Infra.Data.Profiles;

public class EpisodeProfile : Profile
{
    private IMapper _mapper;
    public EpisodeProfile()
    {
        CreateMap<CreateEpisodeDto, Episode>();
        CreateMap<ReadEpisodeDto, Episode>();
        CreateMap<Episode, ReadEpisodeDto>()
            .ForMember(ep => ep.Anime, opt => opt.MapFrom(o => o.Anime));
        CreateMap<Episode, EpisodeDto>();
        CreateMap<UpdateEpisodeDto, Episode>();
        
        //CreateMap<AnimeEntity, AnimeDto>();
    }
}
