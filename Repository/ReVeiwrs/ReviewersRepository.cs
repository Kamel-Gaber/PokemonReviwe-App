

namespace PokemonReviewApp.Repository.ReVeiwrs
{
    public class ReviewersRepository : IReviewersRepository
    {
        private readonly PokemonAppDbContext _context;

        public ReviewersRepository(PokemonAppDbContext context)
        {
            _context = context;
        }

        public Reviewer GetReviewerById(int reviewerid)
        {
            return _context.reviewers.Where(i => i.Id == reviewerid).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewersid)
        {
            return _context.reviews.Where(i=>i.reviewer.Id == reviewersid).ToList();
        }

        public bool ReviewersExisted(int reviewersid)
        {
            return _context.reviewers.Any(i => i.Id == reviewersid);
        }
    }
}
