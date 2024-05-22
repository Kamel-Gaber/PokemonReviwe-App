
namespace PokemonReviewApp.Repository.CounTry
{
    public class CountryRepository : ICountryRepository
    {
        private readonly PokemonAppDbContext _context;

        public CountryRepository(PokemonAppDbContext context)
        {
            _context = context;
        }
        public bool CountryExisted(int id)
        {
            return _context.countries.Any(i=> i.Id == id);
        }

        public bool CountryExistsByName(string name)
        {
            return _context.countries.Any(n => n.Name == name);
        }

        public ICollection<Country> GetCountries()
        {
            return  _context.countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.countries.Where(i => i.Id == id).FirstOrDefault();
        }

        public Country GetCountryByName(string name)
        {
            return _context.countries.Where(n => n.Name == name ).FirstOrDefault();
        }

        public ICollection<Owner> GetCountryByOwner(int countryid)
        {
            return _context.owners.Where(i => i.country.Id == countryid).ToList();

        }


    }
}
