using bacics_of_implementation.Models;

namespace bacics_of_implementation.Repository
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly List<details> Details = new()
        {
            new details { name = "fayis", age = 20, department = "dotnet" },
            new details { name = "jithin", age = 25, department = "flutter" }
        };

        public async Task<IEnumerable<details>> GetAll()
        {
            await Task.Delay(10);
            return Details;
        }
    }   
}
