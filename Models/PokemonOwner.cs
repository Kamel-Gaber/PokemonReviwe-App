namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set;}

        public Owner owner { get; set; }
        public Pokemon pokemon { get; set; }
    }
}
