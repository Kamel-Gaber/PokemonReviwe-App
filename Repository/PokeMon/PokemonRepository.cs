namespace PokemonReviewApp.Repository.PokeMon
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonAppDbContext _context;

        public PokemonRepository(PokemonAppDbContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemonById(int id)
        {
            return _context.pokemons.Where(i => i.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemonByName(string name)
        {
            return _context.pokemons.FirstOrDefault(i => i.Name == name);
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var reviews = _context.reviews.Where(p=> p.pokemon.Id == pokemonId);   
            if(reviews.Count()<=0) {
            
            return 0;
            }
            return ((decimal)reviews.Sum(r => r.Rating)/reviews.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExisted(int pokemonId)
        {
            return _context.pokemons.Any(i => i.Id == pokemonId);
        } 
    }

}
