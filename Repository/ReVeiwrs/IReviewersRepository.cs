namespace PokemonReviewApp.Repository.ReVeiwrs
{
    public interface IReviewersRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewerById(int reviewerid);
        ICollection<Review> GetReviewsByReviewer(int reviewersid);
        bool ReviewersExisted(int reviewersid);
    }
}
