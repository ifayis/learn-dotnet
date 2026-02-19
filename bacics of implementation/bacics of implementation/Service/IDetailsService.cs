using bacics_of_implementation.Models;

namespace bacics_of_implementation.Service
{
    public interface IDetailsService
    {
       Task<IEnumerable<details>> GetDetailsAsync();
    }
}
