
namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllCountry")]
        public IActionResult GetAllCountry()
        {
            if (ModelState.IsValid)
            {
                var result = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
                return Ok(result);
            }
            return BadRequest(ModelState);

        }

        [HttpGet("GetCountryById/{Id}")]
        public IActionResult GetCountryById(int Id)
        {
            if (ModelState.IsValid)
            {
                if (_countryRepository.CountryExisted(Id))
                {
                    var result = _mapper.Map<CountryDto>(_countryRepository.GetCountryById(Id));
                    return Ok(result);
                }
                return BadRequest("This Country Doesnt Existed !");
            }
            return BadRequest();
        }

        [HttpGet("GetCountryByName/{Name}")]
        public IActionResult GetCountryByName(string Name)
        {
            if (ModelState.IsValid)
            {
                if (_countryRepository.CountryExistsByName(Name))
                {
                    var result = _mapper.Map<CountryDto>(_countryRepository.GetCountryByName(Name));
                    return Ok(result);
                }
                return BadRequest("This Country Doesnt Existed !");
            }
            return BadRequest();
        }
        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<List<OwnerDto>>(
                _countryRepository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }
    }
}
