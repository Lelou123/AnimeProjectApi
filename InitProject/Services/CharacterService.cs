using AutoMapper;
using InitProject.Infra.Data.Repository;
using InitProject.Model.Dto.Anime;
using InitProject.Model.Dto.Character;
using InitProject.Model.Entities;
using InitProject.Model.Interfaces.Repository;
using InitProject.Model.Interfaces.Services;
using InitProject.Model.Models;
using NuGet.Protocol;

namespace InitProject.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly ICharacterRepository _characterRepo;
        public CharacterService(IMapper mapper, ICharacterRepository characterRepo)
        {
            _mapper = mapper;
            _characterRepo = characterRepo;
        }
        public async Task<Character> CharactersGetById(int id)
        {
            var character = await _characterRepo.GetByIdAsync(id);

            return character;
        }

        public async Task<PagedResponse<ReadCharacterDto>> CharactersGetAllAsync(int pageSize, int pageNumber)
        {
            var characters = await _characterRepo.GetAllAsync();

            var charactersDto = _mapper.ProjectTo<ReadCharacterDto>(characters.AsQueryable()).OrderBy(x=> x.Id).ToList();            

            PageDefaultValue filterRequet = new()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = characters.Count()
            };

            var response = PageItems.GetPagedItems(charactersDto, filterRequet);

            return response;
        }

        public async Task CreateCharactersAsync(Character createCharacter)
        {
            await _characterRepo.InsertAsync(createCharacter);
        }


        public async Task<bool> DeleteCharactersAsync(int id)
        {
            try
            {
                await _characterRepo.DeleteAsync(id);
            }
            catch (Exception) { return false; }


            return true;
        }

        public async Task<bool> UpdateCharactersAsync(UpdateCharacterDto updateCharacters)
        {
            var character = await CharactersGetById(updateCharacters.Id);

            _mapper.Map(updateCharacters, character);

            try 
            {
                await _characterRepo.UpdateAsync(character); 
            }catch (Exception) { return false; } 
            
            
            return true;
        }
    }
}
