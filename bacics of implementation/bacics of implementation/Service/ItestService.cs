using bacics_of_implementation.Models;

namespace bacics_of_implementation.Service
{
    public interface ItestService
    {
         List<test> GetAllData();
         test GetById(int id);
         test create(test tested);
         test update(int id, test tested);
         bool delete(int id); 
    }
}
