using AutoMapper;
using InitProject.Model.Dto;
using InitProject.Model.Dto.Character;
using InitProject.Model.Models;

namespace InitProject.Infra.Data.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile() 
    {
        CreateMap<CreateCharacterDto, Character>();
        
        CreateMap<Character, CreateCharacterDto>();
        
        CreateMap<ReadCharacterDto, Character>();
        
        CreateMap<Character, ReadCharacterDto>();

        CreateMap<Character, CharacterDto>();

        CreateMap<UpdateCharacterDto, Character>();
    }
}
