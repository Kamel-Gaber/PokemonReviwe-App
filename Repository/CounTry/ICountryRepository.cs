namespace PokemonReviewApp.Repository.CounTry
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int id);
        Country GetCountryByName(string name);
        bool CountryExisted(int id);
        bool CountryExistsByName(string name);
        ICollection<Owner> GetCountryByOwner(int ownerid);

    }

}
