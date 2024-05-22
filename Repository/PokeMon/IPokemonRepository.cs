using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace PokemonReviewApp.Repository.PokeMon
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonById(int id);
        Pokemon GetPokemonByName(string name);
        decimal GetPokemonRating(int pokemonId);
        bool PokemonExisted(int pokemonId); 

    }
}
