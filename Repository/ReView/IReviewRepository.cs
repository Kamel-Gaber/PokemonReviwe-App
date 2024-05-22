namespace PokemonReviewApp.Repository.ReView
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReviewById(int revid);
        ICollection<Review> GetAllReviewOfPokemon(int pokeid);
        bool ReviewExisted(int revid);
    }
}
