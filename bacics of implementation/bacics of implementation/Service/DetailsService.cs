using bacics_of_implementation.Models;
using bacics_of_implementation.Repository;

namespace bacics_of_implementation.Service
{
    public class DetailsService : IDetailsService
    {
        private readonly IDetailsRepository _detailsRepository;

        public DetailsService(IDetailsRepository repository)
        {
            _detailsRepository = repository;
        }

        public IEnumerable<details> GetAll()
        {
            return _detailsRepository.GetAll();
        }

    }
}
