using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly IPokemonRepository _pokemonRepository;

        public OwnerController(IOwnerRepository ownerRepository , IMapper mapper , IPokemonRepository pokemonRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _pokemonRepository = pokemonRepository;
        }
        [HttpGet("GetAllOwners")]
        public IActionResult GetGetAllOwners() { 
         if(ModelState.IsValid)
            {
                var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
                return Ok(owners);
            }
          return BadRequest(ModelState);
        
        }
        [HttpGet("GetOwnerById/{ownerid}")]
        public IActionResult GetOwnerById(int ownerid) {
            if (ModelState.IsValid)
            {
                if (_ownerRepository.IsOwnerExistedById(ownerid))
                {
                    var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwnerById(ownerid));
                    return Ok(owner);
                }
                return BadRequest($"This Owner With Id = {ownerid} Doesnt Existed");

            }
            return BadRequest(ModelState);

        }
        [HttpGet("GetOwnerByName/{ownername:alpha}")]
        public IActionResult GetOwnerByName(string ownername)
        {
            if (ModelState.IsValid)
            {
                if (_ownerRepository.IsOwnerExistedByFirstName(ownername) || _ownerRepository.IsOwnerExistedByLastName(ownername))
                {
                    var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwnerByName(ownername));
                    return Ok(owner);
                }
                return BadRequest($"This Owner With Name = {ownername} Doesnt Existed");

            }
            return BadRequest(ModelState);

        } 
        [HttpGet("GetOwnerOfPokemon/{pokemonid}")]
        public IActionResult GetOwnerOfPokemon(int pokemonid)
        {
            if (ModelState.IsValid)
            {
                if (_pokemonRepository.PokemonExisted(pokemonid))
                {
                   var owner = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfPokemon(pokemonid));
                    return Ok(owner);
                }
                return BadRequest("The Pokemon Id Is Not Valid !!");
            }
            return BadRequest(ModelState);

        }
        [HttpGet("GetPokemonByOwner/{ownerid}")]
        public IActionResult GetPokemonByOwner(int ownerid)
        {
            if (ModelState.IsValid)
            {
                if (_ownerRepository.IsOwnerExistedById(ownerid))
                {
                   var pokemo = _mapper.Map<List<PokmonDto>>(_ownerRepository.GetPokemonByOwner(ownerid));
                    return Ok(pokemo);
                }
                return BadRequest("The Owner Id Is Not Valid !!");
            }
            return BadRequest(ModelState);

        }
         
    }
}
