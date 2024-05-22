

namespace PokemonReviewApp.Repository.OwNer
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PokemonAppDbContext _context;

        public OwnerRepository(PokemonAppDbContext context)
        {
            _context = context;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.owners.FirstOrDefault(i => i.Id == id);
        }

        public Owner GetOwnerByName(string name)
        {
            return _context.owners.FirstOrDefault(i => i.FirstName == name);
        }

        public ICollection<Owner> GetOwnerOfPokemon(int pokemonid)
        {
           return _context.pokemonOwners.Where(i=> i.pokemon.Id == pokemonid).Select(o => o.owner).ToList();  
        }

        public ICollection<Owner> GetOwners()
        {
           return _context.owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerid)
        {
            return _context.pokemonOwners.Where(i => i.owner.Id == ownerid).Select(p => p.pokemon).ToList();
        }

        public bool IsOwnerExistedById(int id)
        {
            return _context.owners.Any(i=> i.Id == id);
        }

       

        public bool IsOwnerExistedByFirstName(string name)
        {
            return _context.owners.Any(i => i.FirstName == name) ;
        }
        public bool IsOwnerExistedByLastName(string name)
        {
            return _context.owners.Any(i => i.LastName== name) ;
        }
    }
}
