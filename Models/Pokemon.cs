using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public ICollection<Review> reviews { get; set; }   
        public ICollection<PokemonCategory> pokemonCategories { get; set;  }

        public ICollection<PokemonOwner> pokemonOwners { get; set;}

    }
}
