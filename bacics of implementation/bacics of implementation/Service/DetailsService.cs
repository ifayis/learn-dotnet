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

        public async Task<IEnumerable<details>> GetDetailsAsync()
        {
           return await _detailsRepository.GetAll();
        }

    }
}
