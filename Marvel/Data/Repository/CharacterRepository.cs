using Marvel.Api.Domain.Models.Entities;
using Marvel.Domain.Interfaces;

namespace Marvel.Data.Repository
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(MarvelContext context) : base(context)
        {
        }
    }
}
