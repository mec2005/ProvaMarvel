using Marvel.Api.Domain.Models.Entities;
using Marvel.Data.Repository;
using Marvel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public Task<IEnumerable<Character>> GetCharacters()
        {
            return _characterRepository.GetAll();
        }

        public Task<Character> GetCharacterById(int characterId)
        {
            return _characterRepository.GetById(characterId);
        }
    }
}
