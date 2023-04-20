using InitProject.Model.Entities;
using InitProject.Model.Models;
using InitProject.Model.Dto.Character;

namespace InitProject.Model.Interfaces.Services;

public interface ICharacterService
{
    Task CreateCharactersAsync(Character createCharacter);
    Task<PagedResponse<ReadCharacterDto>> CharactersGetAllAsync(int pageSize, int pageNumber);
    Task<Character> CharactersGetById(int id);
    Task<bool> UpdateCharactersAsync(UpdateCharacterDto updateCharacters);
    Task<bool> DeleteCharactersAsync(int id);
}
