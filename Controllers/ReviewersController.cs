using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Repository.ReVeiwrs;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly IReviewersRepository _reviewersRepository;
        private readonly IMapper _mapper;

        public ReviewersController(IReviewersRepository reviewersRepository, IMapper mapper)
        {
         
            _reviewersRepository = reviewersRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllReviewers")]
        public IActionResult GetAllReviewers() 
        {
            if (ModelState.IsValid)
            {
                var reviewers = _mapper.Map<List<ReviewersDto>>(_reviewersRepository.GetReviewers());
                return Ok(reviewers);       
            }
            return BadRequest(ModelState);
        }
           [HttpGet("GetReviewerById/{reviewersid:int}")]
        public IActionResult GetReviewerById(int reviewersid)
        {
            if (ModelState.IsValid)
            {
                if (_reviewersRepository.ReviewersExisted(reviewersid))
                {
                    var reviewer = _mapper.Map<ReviewersDto>(_reviewersRepository.GetReviewerById(reviewersid));
                    return Ok(reviewer);
                }
                return BadRequest("This Reviewers Doesnt Existed !");
              
            }
            return BadRequest(ModelState);
        }
    }
}
