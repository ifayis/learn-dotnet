using review_week2.Model;

namespace review_week2.Services
{
    public interface IStudentService
    {
        List<Students> GetAll();
        Students Add(Students student);
        Students? Update(int id, Students student);
        bool Delete(int id);
    }
}
