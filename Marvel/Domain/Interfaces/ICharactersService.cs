using Marvel.Api.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Domain.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character> GetCharacterById(int characterId);
    }
}
