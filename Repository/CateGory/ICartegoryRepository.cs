
namespace PokemonReviewApp.Repository.CateGory
{
    public interface ICartegoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int categoryid);
        Category GetCategoryByName(string categoryname);

        ICollection<Pokemon> GetPokemonByCategory(int categoryid);
        
        bool CategoryExisted(int categoryid);
    
    
    }
}
