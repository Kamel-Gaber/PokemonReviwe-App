
namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICartegoryRepository _cartegoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICartegoryRepository cartegoryRepository, IMapper mapper)
        {
            _cartegoryRepository = cartegoryRepository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                List<CategoryDto> result = _mapper.Map<List<CategoryDto>>(_cartegoryRepository.GetCategories());

                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetCategoryById/{Id}")]
        public IActionResult GetCategoryById([FromRoute] int Id)
        {
            if (_cartegoryRepository.CategoryExisted(Id)) {
                if (ModelState.IsValid)
                {
                    var category = _mapper.Map<CategoryDto>(_cartegoryRepository.GetCategoryById(Id));
                    return Ok(category);
                }
                return BadRequest(ModelState);
            }
            return BadRequest("This category doesnt exist");
        }
        [HttpGet("GetCategoryByName/{Name:alpha}")]
        public IActionResult GetCategoryByName([FromRoute] string Name)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryDto>(_cartegoryRepository.GetCategoryByName(Name));
                return Ok(category);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetPokemonByCategoryId/{Id}")]
        public IActionResult GetPokemonByCategoryId(int Id)
        {
            if (ModelState.IsValid)
            {
                if (_cartegoryRepository.CategoryExisted(Id))
                {
                    var pokemons = _mapper.Map<List<PokmonDto>>(_cartegoryRepository.GetPokemonByCategory(Id));
                    return Ok(pokemons);
                }
                return BadRequest($"This Category With Id = {Id} Doesnt Existed !");

            }return BadRequest(ModelState); 
           
        }


    }
}
