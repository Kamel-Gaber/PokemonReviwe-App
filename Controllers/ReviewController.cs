using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PokemonReviewApp.Repository.ReView;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IPokemonRepository _pokemonRepository;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper , IPokemonRepository pokemonRepository)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _pokemonRepository = pokemonRepository;
        }

        public IReviewRepository ReviewRepository { get; }

        [HttpGet("GetAllReviews")]
        public IActionResult GetAllReviews()
        {
            if (ModelState.IsValid)
            {
                var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
                return Ok(reviews);

            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetReviewsById/{reviewid}")]
        public IActionResult GetReviewsById(int reviewid)
        {
            if (ModelState.IsValid)
            {
                if (_reviewRepository.ReviewExisted(reviewid))
                {
                    var reviews = _mapper.Map<ReviewDto>(_reviewRepository.GetReviewById(reviewid));
                    return Ok(reviews);
                }
                return BadRequest("The Review is not found");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetAllPokemReviews/{pokemonid}")]
        public IActionResult GetAllPokemReviews(int pokemonid) 
        {
            if (ModelState.IsValid)
            {
                if (_pokemonRepository.PokemonExisted(pokemonid))
                {
                    var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetAllReviewOfPokemon(pokemonid));
                    return Ok(reviews);
                }
                return BadRequest("The Pokemon not found !");
            }
            return BadRequest(ModelState);

        }

    }
}
