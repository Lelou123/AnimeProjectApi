using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Profiles;

public class EpisodeProfile : Profile
{
    public EpisodeProfile()
    {
        CreateMap<CreateEpisodeDto, Episode>();
        
        CreateMap<ReadEpisodeDto, Episode>();

        CreateMap<Episode, ReadEpisodeDto>()
            .ForMember(ep => ep.Anime, opt => opt.MapFrom(o => o.Anime));

        CreateMap<Episode, EpisodeDto>();
        
        CreateMap<UpdateEpisodeDto, Episode>();
        
    }
}
