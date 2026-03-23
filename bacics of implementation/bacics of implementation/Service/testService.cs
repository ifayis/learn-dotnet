using bacics_of_implementation.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace bacics_of_implementation.Service
{
    public class testService : ItestService
    {
        private static List<test> _testing = new List<test>();
        private static int _next = 1;

        public List<test> GetAllData()
        {
            return _testing;
        }

        public test GetById(int id)
        {
            return _testing.FirstOrDefault(a => a.id == id);
        }

        public test create(test tested)
        {
            tested.id = _next++;
            _testing.Add(tested);
            return tested;
        }

        public test update(int id, test tested)
        {
            var result = _testing.FirstOrDefault(a => a.id == id);
            result.name = tested.name;
            return tested;
        }

        public bool delete(int id)
        {
            var result = _testing.FirstOrDefault(a => a.id == id);
            _testing.Remove(result);
            return true;
        }
    }
}
