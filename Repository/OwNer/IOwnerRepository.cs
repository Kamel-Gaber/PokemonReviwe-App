namespace PokemonReviewApp.Repository.OwNer
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwnerById(int id);
        Owner GetOwnerByName(string name);
        bool IsOwnerExistedById(int id);
        bool IsOwnerExistedByFirstName(string name);
        bool IsOwnerExistedByLastName(string name);
        ICollection<Owner> GetOwnerOfPokemon(int pokemonid);
        ICollection<Pokemon> GetPokemonByOwner(int ownerid);
    }
}
