using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Dto.Estudio;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Profiles;

public class EstudioProfile : Profile
{
    public EstudioProfile() 
    {
        CreateMap<Estudio, ReadEstudioDto>()
            .ForMember(o=> o.AnimeEstudio, opt=> opt.MapFrom(x=> x.AnimesEstudios));
        
        CreateMap<ReadEstudioDto, Estudio>();

        CreateMap<CreateEstudioDto, Estudio>();        

        CreateMap<EstudioDto, Estudio>();
    }
}
