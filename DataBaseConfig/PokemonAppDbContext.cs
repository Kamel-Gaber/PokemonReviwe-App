
namespace PokemonReviewApp.DataBaseConfig
{
    public class PokemonAppDbContext :  DbContext
    {
        public PokemonAppDbContext(DbContextOptions<PokemonAppDbContext> options):base(options) 
        {
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Pokemon> pokemons { get; set; }

        public DbSet<PokemonOwner> pokemonOwners  { get; set; }
        public DbSet<PokemonCategory>  pokemonCategories { get; set; }
        public DbSet<Review> reviews  { get; set; }
        public DbSet<Reviewer> reviewers  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>().HasKey(pc => new { pc.PokemonId , pc.CategoryId});
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.pokemon)
                .WithMany(pc => pc.pokemonCategories)
                .HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
               .HasOne(p => p.category)
               .WithMany(pc => pc.pokemonCategories)
               .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>().HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.pokemon)
                .WithMany(po => po.pokemonOwners)
                .HasForeignKey(oi => oi.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(o => o.owner)
                .WithMany(po => po.pokemonOwners)
                .HasForeignKey(oi => oi.OwnerId);



        }
    }
}
