using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository.PokeMon;

namespace PokemonReviewApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository , IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }
        [HttpGet("GetPokemons")]
        public IActionResult GetPokemon()
        {
            var pokemon = _mapper.Map<List<PokmonDto>>(_pokemonRepository.GetPokemons());
            return Ok(pokemon);
        }

        [HttpGet("GetPokemonsById/{pokemonId:int}")]
        public IActionResult GetPokemonsById([FromRoute]int pokemonId)
        {
            var pokemon =_mapper.Map<PokmonDto>(_pokemonRepository.GetPokemonById(pokemonId));
            if (pokemon == null)
            {
                return BadRequest("The Pokemon Doesnt Existed !!");
            }

            if(ModelState.IsValid) { return Ok(pokemon); }
            else { return BadRequest(); }
           
        }
        [HttpGet("GetPokemonsByName/{pokemonName:alpha}")]
        public IActionResult GetPokemonsByName([FromRoute] string pokemonName)
        {
            var pokemon = _mapper.Map<PokmonDto>(_pokemonRepository.GetPokemonByName(pokemonName));
             if (pokemon == null)
            {
                return BadRequest("Not Found");
            }
             if (ModelState.IsValid) { return Ok(pokemon); }
             else { return BadRequest(ModelState); }
                
        }

        [HttpGet("GetPokemonsById/{pokemonId:int}/rating")]
        public IActionResult GetPokemonRating([FromRoute] int pokemonId)
        {
            var pokemon = _pokemonRepository.GetPokemonRating(pokemonId);
       

            if (ModelState.IsValid) { return Ok(pokemon); }
            else { return BadRequest(); }

        }


    }
}
