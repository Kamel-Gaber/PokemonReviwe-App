
namespace PokemonReviewApp.Repository.ReView
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PokemonAppDbContext _context;

        public ReviewRepository(PokemonAppDbContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetAllReviewOfPokemon(int pokeid)
        {
           return _context.reviews.Where(i=> i.pokemon.Id == pokeid).ToList(); 
        }

        public Review GetReviewById(int revid)
        {
            return _context.reviews.Where(i => i.Id == revid).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.reviews.OrderBy(i => i.Id).ToList();
        }

        public bool ReviewExisted(int revid)
        {
          return _context.reviews.Any(i => i.Id == revid);  
        }
    }
}
