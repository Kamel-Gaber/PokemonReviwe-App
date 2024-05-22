
namespace PokemonReviewApp.Helper
{
    public class MappingProfiels : Profile
    {
        public MappingProfiels()
        {
            CreateMap<Pokemon, PokmonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewersDto>();
            
        }
    }
}
