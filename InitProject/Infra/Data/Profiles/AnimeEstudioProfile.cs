using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Profiles;

public class AnimeEstudioProfile : Profile
{
    public AnimeEstudioProfile()
    {
        CreateMap<AnimeEstudio, AnimeEstudioDto>();
    }
}
