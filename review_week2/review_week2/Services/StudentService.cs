using review_week2.Model;

namespace review_week2.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Students> students = new()
        {
            new Students { Id = 1, Name = "mhd", Age = 20 },
            new Students { Id = 2, Name = "fys", Age = 21 }
        };

        public List<Students> GetAll()
        {
           return students;
        }
        public Students Add(Students student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return student;
        }

        public Students? Update(int id, Students updated)
        {
            var stu = students.FirstOrDefault(s => s.Id == id);
            if (stu == null) 
                return null;

            stu.Name = updated.Name;
            stu.Age = updated.Age;
            return stu;
        }

        public bool Delete(int id)
        {
            var stu = students.FirstOrDefault(s => s.Id == id);
            if (stu == null) 
                return false;

            students.Remove(stu);
            return true;
        }
    }
}
