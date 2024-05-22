

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly PokemonAppDbContext dataContext;
        public Seed(PokemonAppDbContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.pokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    new PokemonOwner()
                    {
                        pokemon = new Pokemon()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { Name = "Electric"}}
                            },
                            reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Gym = "Brocks Gym",
                            country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwner()
                    {
                         pokemon = new Pokemon()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { Name = "Water"}}
                            },
                            reviews = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric", Rating = 5,
                                reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                                reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                                reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Gym = "Mistys Gym",
                            country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new PokemonOwner()
                    {
                        pokemon = new Pokemon()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { Name = "Leaf"}}

                            },
                            reviews = new List<Review>()
                            {
                                new Review { Title="Veasaur",Text = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                                reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                                reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            Gym = "Ashs Gym",
                            country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.pokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
