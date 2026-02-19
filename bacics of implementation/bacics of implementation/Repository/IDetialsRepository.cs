using bacics_of_implementation.Models;

namespace bacics_of_implementation.Repository
{
    public interface IDetialsRepository
    {
        IEnumerable<details> GetAll();
    }
}
