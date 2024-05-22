
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository.CateGory
{
    public class CartegoryRepository : ICartegoryRepository

    {
        private readonly PokemonAppDbContext _context;
        public CartegoryRepository(PokemonAppDbContext context )
        {
            _context = context;
        }

        public bool CategoryExisted(int categoryid)
        {
            return _context.categories.Any(i => i.Id == categoryid);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.categories.ToList();
        }

        public Category GetCategoryById(int categoryid)
        {
            return _context.categories.Where(i => i.Id == categoryid).FirstOrDefault();
        }

        public Category GetCategoryByName(string categoryname)
        {
            return _context.categories.Where(i => i.Name == categoryname).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryid)
        {
            return _context.pokemonCategories.Where(i => i.CategoryId == categoryid).Select(c => c.pokemon).ToList();
        }
    }
}
