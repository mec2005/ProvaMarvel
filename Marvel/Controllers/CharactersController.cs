using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Api.Domain.Models.Entities;
using Marvel.Domain.Containers;
using Marvel.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Controllers
{
    [Route("v1/public/[controller]")]
    [ApiController]
    public class CharactersController : BaseApiController<Character>
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<DataWrapper<Character>>> Get()
        {            
            return GetResult(await _characterService.GetCharacters());
        }

        [HttpGet("{characterId}")]
        public async Task<ActionResult<DataWrapper<Character>>> Get(int characterId)
        {
            return GetResult(await _characterService.GetCharacterById(characterId));
        }

        #region Not Implemented
        [HttpGet("{characterId}/comics")]
        public ActionResult<string> GetComics(int characterId)
        {
            return BadRequest(new NotImplementedException());
        }

        [HttpGet("{characterId}/events")]
        public ActionResult<string> GetEvents(int characterId)
        {
            return BadRequest(new NotImplementedException());
        }

        [HttpGet("{characterId}/series")]
        public ActionResult<string> GetSeries(int characterId)
        {
            return BadRequest(new NotImplementedException());
        }

        [HttpGet("{characterId}/stories")]
        public ActionResult<string> GetStories(int characterId)
        {
            return BadRequest(new NotImplementedException());
        } 
        #endregion
    }
}
